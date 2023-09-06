namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<PokemonAbility> Ability { get; set; }
        public List<PokemonType> Type { get; set; }
    }
}
