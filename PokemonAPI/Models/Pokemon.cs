using Newtonsoft.Json;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        [JsonProperty(PropertyName = "abilities")]
        public List<PokemonAbility> Abilities { get; set; }
        //public List<PokemonType> Type { get; set; }
    }
}