using Newtonsoft.Json;
using PokemonAPI.Models;
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
        public async Task<PokeapiBase> GetPokemonList()
        {
            PokeapiBase pokeapiBase = new PokeapiBase();
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrlPokeapi);
            try 
            {
                if (response != null && response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<PokeapiBase>(json_response);
                    pokeapiBase = result;
                }
            }
            catch 
            {
                Console.WriteLine("error en el servicio GetPokemonList");
            }

            return pokeapiBase;
        }
        public Task<Pokemon> GetPokemon(string name)
        {
            throw new NotImplementedException();
        }
    }
}
