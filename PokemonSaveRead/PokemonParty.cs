using System.Collections.Generic;

namespace PokemonSaveRead
{
    public class PokemonParty
    {
        public List<Pokemon> Party { get; set; }

        public PokemonParty()
        {
            this.Party = new List<Pokemon>();
        }
    }
}