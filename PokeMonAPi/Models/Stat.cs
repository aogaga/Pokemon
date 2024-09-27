using System.Text.Json.Serialization;

namespace PokeMonAPi.Models
{
    public class Stat
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
