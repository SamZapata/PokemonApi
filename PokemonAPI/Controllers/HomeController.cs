using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using System.Diagnostics;
using PokemonAPI.Services;
using System.Xml.Linq;

namespace PokemonAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResultApi _resultApi;

        public HomeController(IResultApi resultApi)
        {
            _resultApi = resultApi;
        }

        [HttpGet("pokemons")]
        public async Task<IActionResult> Index()
        {
            ResultAPI result = await _resultApi.GetResults();
            Pokemon pokemon = new Pokemon();
            List<Pokemon> pokemonList = new List<Pokemon>();
            foreach (var poke in result.Results)
            {
                if (poke.Name != null || poke.Name != "")
                {
                    pokemon.Url = poke.Url;
                    pokemon = await _resultApi.GetPokemon(poke.Name);
                    pokemonList.Add(pokemon);
                }
            }
            return Ok(pokemonList);
        }

        [HttpGet("pokemons/{name}")]
        public async Task<IActionResult> Pokemon(string name)
        {
            Pokemon pokemon = new Pokemon();
            if (name != null || name != "") 
            {
                pokemon = await _resultApi.GetPokemon(name);
            }

            return Ok(pokemon);
        }

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