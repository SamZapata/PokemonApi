using PokemonAPI.Models;

namespace PokemonAPI.Services
{
    public interface IResultApi
    {
        Task<ResultAPI> GetResults();
        Task<Pokemon> GetPokemon(string name);
    }
}
