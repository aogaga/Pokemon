using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using PokeMonAPi.Controllers;
using PokeMonAPi.Models;
using PokeMonAPi.Repositories;

namespace PokeMonAPi.Services;

public class PokemonService(ILogger<PokemonService> logger, IPokemonRepository pokemonRepository, IDistributedCache cache, RedisService redis)
    : IPokemonService
{
    public Task<List<Pokemon?>?> GetAllPokemonsAsync()
    {
        return Task.FromResult(pokemonRepository.All());
    }

    public async Task<Pokemon?> GetPokemonAsync(int number)
    {
        var pokemonList = await GetAllPokemonsAsync();
        return pokemonList?.FirstOrDefault(x => x != null && x.Number == number);
    }


    public async Task<int> CountAsync()
    {
        var pokemons = await GetAllPokemonsAsync();
        return pokemons?.Count() ?? 0;
    }


    public async Task<Dictionary<string, int>> GetPokemonGenerationsAsync()
    {
        var pokemonList = GetAllPokemonsAsync();
        var map = new Dictionary<string, int>();

        foreach (var x in (await pokemonList)!)
        {
            if (x == null) continue;
            if (map.TryAdd(x.Generation, 1)) continue;
            var tempCount = map[x.Generation];
            tempCount++;
            map[x.Generation] = tempCount;
        }

        return map;
    }

    public async Task<Dictionary<string, int>> GetPokemonTypesAsync()
    {
        var pokemonList = await GetAllPokemonsAsync(); // Await the async call
        var map = new Dictionary<string, int>();

        if (pokemonList == null) return map;
        foreach (var typeItem in pokemonList.OfType<Pokemon>().Select(pokemon => pokemon.Types)
                     .SelectMany(pokemonTypeArray =>
                         pokemonTypeArray.Where(typeItem => !string.IsNullOrEmpty(typeItem))))
            if (map.TryGetValue(typeItem, out var count))
                map[typeItem] = count + 1; // Increment the count
            else
                map[typeItem] = 1; // Initialize the count

        return map;
    }


    public async Task<DashBoard?> GetDashBoardDataAsync()
    {
        const string cacheKey = "dashBoardData";


        try
        {
            var cachedData = await redis.ReadValueAsync(cacheKey);
            if (!cachedData.IsNullOrEmpty)
                // Deserialize the cached data and return it
                return JsonSerializer.Deserialize<DashBoard>(cachedData.ToString());


            // Create a new DashBoard instance with fresh data
            var dashBoard = new DashBoard
            {
                Pokemons = await GetPokemonDtos(),
                PokemonGenerations = await GetPokemonGenerationsAsync(),
                PokemonTypes = await GetPokemonTypesAsync()
            };

            // Serialize the dashboard data to store it in Redis


            var serializedData = JsonSerializer.Serialize(dashBoard);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(50)
            };
            await redis.WritetValueAsync(cacheKey, serializedData, options);

            return dashBoard;
        }
        catch (Exception ex)
        {
            // Handle exceptions (log them, rethrow, etc.)
            throw new DataRetrievalException("Failed to retrieve dashboard data.", ex);
        }
    }

    private async Task<List<PokemonDto?>> GetPokemonDtos()
    {
        var pokemons = pokemonRepository.All();

        if (pokemons == null) throw new ArgumentNullException(nameof(pokemons), "Pokemons cannot be null.");

        return pokemons.Select(pokemon =>
            {
                if (pokemon != null)
                    return new PokemonDto
                    {
                        MovesCount = pokemon.Moves.Count,
                        Name = pokemon.Name,
                        Number = pokemon.Number,
                        Generation = pokemon.Generation,
                        Height = pokemon.Height,
                        Weight = pokemon.Weight,
                        Typeone = pokemon.Types[0],
                        Typetwo = pokemon.Types[1]
                    };

                return null;
            })
            .ToList();
    }
}