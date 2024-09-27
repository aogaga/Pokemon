using System.Text.Json.Serialization;

namespace PokeMonAPi.Models
{

    public class Pokemon
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("generation")]
        public string Generation { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; }

        [JsonPropertyName("moves")]
        public List<string> Moves { get; set; }

        [JsonPropertyName("abilities")]
        public List<string> Abilities { get; set; }

        [JsonPropertyName("evolution")]
        public Evolution Evolution { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
