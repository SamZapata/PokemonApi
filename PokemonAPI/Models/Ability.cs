using Newtonsoft.Json;

namespace PokemonAPI.Models
{
    public class Ability
    {
        //[JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        
        //[JsonProperty(PropertyName = "url")]
        public string url { get; set; }
    }
}
