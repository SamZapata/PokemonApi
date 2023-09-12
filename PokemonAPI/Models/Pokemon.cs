using Newtonsoft.Json;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        [JsonProperty]
        public int Id { get; set; }
        
        [JsonProperty]
        public string Name { get; set; }
        
        [JsonProperty]
        public string Url { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        
        [JsonProperty(PropertyName = "abilities")]
        public List<PokemonAbility> Abilities { get; set; }
        
        [JsonProperty("types")]
        public List<PokemonType> Types { get; set; }
    }
}