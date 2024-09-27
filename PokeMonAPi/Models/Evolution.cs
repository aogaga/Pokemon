using System.Text.Json.Serialization;

namespace PokeMonAPi.Models
{
    public class Evolution
    {
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public List<string> To { get; set; }
    }
}
