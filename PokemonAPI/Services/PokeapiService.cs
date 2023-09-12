using Newtonsoft.Json;
using PokemonAPI.Models;
using System.Net;
using System.Text.Json;

namespace PokemonAPI.Services
{
    public class PokeapiService : IPokeapiService
    {
        private static string _baseUrlPokeapi;

        public PokeapiService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrlPokeapi = builder.GetSection("ApiSettings:BaseUrl").Value;
        }
        public async Task<List<Pokemon>> GetPokemonsList(int amount)
        {
            PokeapiBase pokeapiBase = new PokeapiBase();
            List<Pokemon> pokemonsList = new List<Pokemon>();
            try 
            {
                var client = new HttpClient();
                if (amount > 0)
                {
                    for (int i = 1; i <= amount; i++)
                    {
                        Pokemon pokemon = new Pokemon();
                        pokemon.Abilities = new List<PokemonAbility>();
                        var response = await client.GetAsync($"{_baseUrlPokeapi}/{i}");
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            var json_response = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<Pokemon>(json_response);
                            pokemon = result;
                            pokemonsList.Add(pokemon);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("=================error en el servicio GetPokemonList========");
                Console.WriteLine(ex.Message);
            }

            return pokemonsList;
        }
        public Task<Pokemon> GetPokemon(string name)
        {
            throw new NotImplementedException();
        }
    }
}
