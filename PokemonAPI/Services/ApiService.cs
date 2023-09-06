using Newtonsoft.Json;
using PokemonAPI.Models;
using System.Net.Http.Headers;
using System.Text;

namespace PokemonAPI.Services
{
    public class ApiService : IResultApi
    {
        private static string _baseUrl;

        public ApiService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<ResultAPI> GetResults()
        {
            ResultAPI resultApi = new ResultAPI();
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);

            if(response != null && response.IsSuccessStatusCode) 
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultAPI>(json_response);
                resultApi = result;
            }

            return resultApi;
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            Pokemon pokemon = new Pokemon();
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{name}");
            if (response != null && response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Pokemon>(json_response);
                pokemon = result;
            }

            return pokemon;
        }
    }
}
