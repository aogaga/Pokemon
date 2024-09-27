using PokeMonAPi.Models;

namespace PokeMonAPi.Services
{
    public interface IPokemonService
    {
        public Task<List<Pokemon?>?> GetAllPokemonsAsync();
        public Task<Pokemon?> GetPokemonAsync(int number);
        public Task<Dictionary<string, int>> GetPokemonGenerationsAsync();
        public Task<Dictionary<string, int>> GetPokemonTypesAsync();
        public Task<DashBoard?> GetDashBoardDataAsync();


    }
}
