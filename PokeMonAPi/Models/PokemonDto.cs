using System.Text.Json.Serialization;

namespace PokeMonAPi.Models
{
    public class PokemonDto
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

        [JsonPropertyName("typesone")]
        public string Typeone { get; set; }

        [JsonPropertyName("typestwo")]
        public string Typetwo { get; set; }

        [JsonPropertyName("movescCount")]
        public int MovesCount { get; set; }

      
    }
}
