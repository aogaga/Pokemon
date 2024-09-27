using System.Text.Json.Serialization;

namespace PokeMonAPi.Models;

public class DashBoard
{
    [JsonPropertyName("pokemons")]
    public List<PokemonDto?>? Pokemons { get; set; }

    [JsonPropertyName("pokemontypes")]
    public Dictionary<string, int> PokemonTypes { get; set; }


    [JsonPropertyName("pokemongenerations")]
    public Dictionary<string, int> PokemonGenerations { get; set; }

   
}