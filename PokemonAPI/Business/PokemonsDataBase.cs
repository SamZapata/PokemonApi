using PokemonAPI.Models;

namespace PokemonAPI.Business
{
    public class PokemonsDataBase
    {
        private List<PokeapiBaseResult> listBaseResult;

        //public List

        public List<PokeapiBaseResult> GetPokeapiBaseResult(PokeapiBase data)
        {
            PokeapiBaseResult pokeapiBaseResult;
            listBaseResult = new List<PokeapiBaseResult>();
            if (data.Count > 0 && data.Results != null)
            {
                foreach (var pokemon in data.Results)
                {
                    listBaseResult.Add(pokemon);
                }
            }

            return listBaseResult;
        }
    }
}
