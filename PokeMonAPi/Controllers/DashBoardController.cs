using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using PokeMonAPi.Models;
using PokeMonAPi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeMonAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashBoardController(ILogger<DashBoardController> logger, IPokemonService pokeMonService) : ControllerBase
    {

        // GET: api/<DashBoardController>
        [HttpGet(Name = "GetDashBoard")]
        public async Task<DashBoard?> Get()
        {
            return await pokeMonService.GetDashBoardDataAsync();

           
        }

     
    }
}
