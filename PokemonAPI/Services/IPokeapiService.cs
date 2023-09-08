using PokemonAPI.Models;

namespace PokemonAPI.Services
{
    public interface IPokeapiService
    {
        Task<PokeapiBase> GetPokemonList();
        Task<Pokemon> GetPokemon(string name);
    }
}
