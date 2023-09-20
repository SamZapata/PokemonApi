using Newtonsoft.Json;
using PokemonAPI.Models;
using System.Net;
using System.Text.Json;

namespace PokemonAPI.Services
{
    public class PokeapiService : IPokeapiService
    {
        private static string _baseUrlPokeapi;
        private static string _seedPath;

        public PokeapiService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrlPokeapi = builder.GetSection("ApiSettings:BaseUrl").Value;
            _seedPath = builder.GetSection("ApiSettings:SeedPath").Value;
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
                        int randomId = new Random().Next(1, 1281);
                        var response = await client.GetAsync($"{_baseUrlPokeapi}/{randomId}");
                        if (response != null && !response.IsSuccessStatusCode)
                        {
                            while (response != null && !response.IsSuccessStatusCode)
                            {
                                randomId = new Random().Next(1, 1281);
                                response = await client.GetAsync($"{_baseUrlPokeapi}/{randomId}");
                                if (response != null && response.IsSuccessStatusCode)
                                {
                                    string json_response = await response.Content.ReadAsStringAsync();
                                    var result = JsonConvert.DeserializeObject<Pokemon>(json_response);
                                    pokemon = result;
                                    pokemonsList.Add(pokemon);
                                }
                            }
                        }
                        else
                        {
                            string json_response = await response.Content.ReadAsStringAsync();
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
                Console.WriteLine("======= Loading JSON File =======");
                pokemonsList = await LoadPokemons();
            }

            return pokemonsList;
        }
        public Task<Pokemon> GetPokemon(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pokemon>> LoadPokemons()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            Pokemon loadPokemon = new Pokemon();

            try
            {
                using (StreamReader r = new StreamReader(_seedPath))
                {
                    string jsonFile = r.ReadToEnd();
                    loadPokemon = JsonConvert.DeserializeObject<Pokemon>(jsonFile);
                    pokemons.Add(loadPokemon);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("========== Error in LoadPokemons method ==========");
                Console.WriteLine($"{ex.Message}");
            }

            return pokemons;
        }

        // Method to refactor the request-response
    }
}
