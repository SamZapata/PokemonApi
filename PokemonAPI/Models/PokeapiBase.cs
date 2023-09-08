namespace PokemonAPI.Models
{
    public class PokeapiBase
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokeapiBaseResult> Results { get; set; }
    }
}
