namespace PokemonAPI.Models
{
    public class ResultAPI
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous {  get; set; }
        public List<Result>? Results { get; set; }

    }
}
