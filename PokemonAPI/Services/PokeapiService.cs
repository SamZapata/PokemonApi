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

                        // To create an offline pokemon
                        //pokemon.Name = "Who is that Pokemon?";
                        //pokemon.Url = "not-url";
                        //pokemon.Types = new List<PokemonType>();
                        //PokemonType pokemonType = new PokemonType()
                        //{
                        //    slot = 000,
                        //    type = new PType() { Name = "not-type", Url = "not-url" }
                        //};
                        //pokemon.Types.Add(pokemonType);
                        //pokemon.Abilities = new List<PokemonAbility>();
                        //PokemonAbility pokemonAbility = new PokemonAbility()
                        //{
                        //    slot = 000,
                        //    ability = new Ability() { name = "not-ability", url = "not-url" }
                        //};
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("=================error en el servicio GetPokemonList========");
                Console.WriteLine(ex);
            }

            return pokemonsList;
        }
        public Task<Pokemon> GetPokemon(string name)
        {
            throw new NotImplementedException();
        }

        // Method to refactor the request-response
    }
}
