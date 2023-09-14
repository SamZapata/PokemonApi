using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using System.Diagnostics;
using PokemonAPI.Services;
//using PokemonAPI.Business;

namespace PokemonAPI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IResultApi _resultApi;
        private readonly IPokeapiService _pokeapiService;

        public HomeController(IPokeapiService pokeapiService)
        {
            _pokeapiService = pokeapiService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                int amount = 5;
                List<Pokemon> dataResult = await _pokeapiService.GetPokemonsList(amount);
                if (dataResult != null && dataResult.Count > 0)
                {
                    ViewData["Message"] = "Pokemons capturados: " + dataResult.Count;
                    ViewData["Pokemons"] = dataResult;
                    return View();
                }
                else
                {
                    ViewData["Message"] = "No se encontraron Pokemons";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.Write("==========Error Home Controller==========");
                Console.WriteLine(ex.ToString());

                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Index(int amount = 5)
        {
            try
            {
                List<Pokemon> dataResult = await _pokeapiService.GetPokemonsList(amount);
                if (dataResult != null && dataResult.Count > 0)
                {
                    ViewData["Message"] = "Pokemons capturados: " + dataResult.Count;
                    ViewData["Pokemons"] = dataResult;
                    ViewData["Amount"] = amount;
                    return View();
                }
                else
                {
                    ViewData["Message"] = "No se encontraron Pokemons";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.Write("==========Error Home Controller==========");
                Console.WriteLine(ex.ToString());

                return BadRequest();
            }
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