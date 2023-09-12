using Newtonsoft.Json;

namespace PokemonAPI.Models
{
    public class PokemonAbility
    {
        [JsonProperty(PropertyName = "ability")]
        public Ability ability { get; set; }

        [JsonProperty("is_hidden")]
        public bool is_hidden { get; set; }
        
        [JsonProperty("slot")]
        public int slot { get; set; }
    }
}