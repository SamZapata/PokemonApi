using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using PokemonAPI.Business;
using PokemonAPI.Models;
using PokemonAPI.Services;

namespace PokemonAPI.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokeapiService _pokeapiService;
        public PokemonController(IPokeapiService pokeapiService)
        {
            _pokeapiService = pokeapiService;
        }

        [Route("pokemon/{name}")]
        public async Task<IActionResult> Show(string name) 
        {
            ViewBag.Pokemon = new Pokemon();
            try
            {
                ViewBag.Name = name.ToUpper();
                var pokemonResult = await _pokeapiService.GetPokemon(name);
                if (pokemonResult != null && pokemonResult.Id > 0 && pokemonResult.Id < 10000)
                {
                    ViewBag.Pokemon = pokemonResult;
                    return View();
                }
                else
                {
                    ViewBag.Pokemon = null;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("============ Erro in Pokemon Controller ============");
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
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
