using PokeMonAPi.Models;

namespace PokeMonAPi.Repositories;

public interface IPokemonRepository
{
   
    public List<Pokemon?>? All();
  
}