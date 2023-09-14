using PokemonAPI.Models;

namespace PokemonAPI.Services
{
    public interface IPokeapiService
    {
        Task<List<Pokemon>> GetPokemonsList(int amount);

        Task<Pokemon> GetPokemon(string name);  
    }
}
