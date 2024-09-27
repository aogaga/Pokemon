using Microsoft.AspNetCore.Mvc;
using PokeMonAPi.Models;
using PokeMonAPi.Services;

namespace PokeMonAPi.Controllers;

[ApiController]
[Route("[controller]")]
public class PokeMonController(ILogger<PokeMonController> logger, IPokemonService pokeMonService) : ControllerBase
{
    [HttpGet(Name = "GetPokemon")]
    public async Task<List<Pokemon?>?> Get()
    {
        return await pokeMonService.GetAllPokemonsAsync();
    }


}