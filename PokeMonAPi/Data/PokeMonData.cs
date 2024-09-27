using PokeMonAPi.Models;
using System.Text.Json;

namespace PokeMonAPi.Data
{
    public static class PokeMonData
    {
        public static async Task<List<Pokemon?>?> GetPokemonsAsync()
        {
            var projectDirectory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(projectDirectory, "pokemon.json");
            try
            {
                
                var pokemonStr = await File.ReadAllTextAsync(filePath);
                List<Pokemon>?  pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(pokemonStr);
                Console.WriteLine(pokemonList);
                return pokemonList;
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine($@"Error: The file was not found. Details: {fnf.Message}");
            }
            catch (JsonException je)
            {
                Console.WriteLine($@"Error: Failed to deserialize JSON. Details :{je.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"An unexpected error occurred: {ex.Message}");
            }
            return [];
        }
    }
}
