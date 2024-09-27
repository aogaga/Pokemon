using PokeMonAPi.Data;
using PokeMonAPi.Models;

namespace PokeMonAPi.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly List<Pokemon?>? _pokemonList = PokeMonData.GetPokemonsAsync().GetAwaiter().GetResult();

   
    public Pokemon? GetPokemon(int number)
    {
        return _pokemonList?.Find(x => x != null && x.Number == number);
    }

    public List<Pokemon?>? All()
    {
        return _pokemonList;
    }

 
}