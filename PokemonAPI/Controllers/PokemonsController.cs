using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using PokemonAPI.Business;
using PokemonAPI.Models;
using PokemonAPI.Services;

namespace PokemonAPI.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly IPokeapiService _pokeapiService;
        public PokemonsController(IPokeapiService pokeapiService)
        {
            //_resultApi = resultApi;
            _pokeapiService = pokeapiService;
        }

        //[HttpGet("pokemons")]
        //public async Task<IActionResult> Index()
        //{
        //    PokeapiBase dataResult = await _pokeapiService.GetPokemonList();
        //    PokemonsDataBase pokedata = new PokemonsDataBase();
        //    List<PokeapiBaseResult> result = pokedata.GetPokeapiBaseResult(dataResult);

        //    return Ok(result);
        //}

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

        // GET: PokemonsController
        public IActionResult Index()
        {
            return View();
        }

        // POST: PokemonsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        // POST: PokemonsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
