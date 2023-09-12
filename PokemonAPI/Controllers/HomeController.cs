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
            _pokeapiService = pokeapiService;
        }

        //public ActionResult Index()
        //{
        //    return View("Index");
        //}

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                int num = 5;
                List<Pokemon> dataResult = await _pokeapiService.GetPokemonsList(num);
                PokemonsDataBase pokedata = new PokemonsDataBase();
                if (dataResult != null && dataResult.Count > 0)
                {
                    //List<PokeapiBaseResult> result = pokedata.GetPokeapiBaseResult(dataResult);
                    ViewData["Message"] = "Pokemons capturados: " + dataResult.Count;
                    ViewData["Pokemons"] = dataResult;
                    return Ok(dataResult);
                }
                else
                {
                    ViewData["Message"] = "No se encontraron Pokemons";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.Write("=============Error en Home Controller");
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