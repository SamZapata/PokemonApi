using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using System.Diagnostics;
using PokemonAPI.Services;
using System.Xml.Linq;
using PokemonAPI.Business;

namespace PokemonAPI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IResultApi _resultApi;
        private readonly IPokeapiService _pokeapiService;

        public HomeController(IPokeapiService pokeapiService)
        {
            //_resultApi = resultApi;
            _pokeapiService = pokeapiService;
        }

        [HttpGet("pokemons")]
        public async Task<IActionResult> Index()
        {
            PokeapiBase dataResult = await _pokeapiService.GetPokemonList();
            PokemonsDataBase pokedata = new PokemonsDataBase();
            List<PokeapiBaseResult> result = pokedata.GetPokeapiBaseResult(dataResult);

            return Ok(result);
        }

        //[HttpGet("pokemons/{name}")]
        //public async Task<IActionResult> Pokemon(string name)
        //{
        //    Pokemon pokemon = new Pokemon();
        //    if (name != null || name != "") 
        //    {
        //        pokemon = await _resultApi.GetPokemon(name);
        //    }

        //    return View(pokemon);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}