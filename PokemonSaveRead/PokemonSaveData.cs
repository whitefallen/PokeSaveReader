using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace PokemonSaveRead
{
    public class PokemonSaveData
    {
        public List<Pokemon> Party { get; set; }
        public string TrainerName { get; set; }
        //public int CurrentBadges { get; set; }
        public string PlayedTime { get; set; }
        public PokemonSaveData()
        {
            this.Party = new List<Pokemon>();
            this.TrainerName = "SampleTrainerName";
            //this.CurrentBadges = 0;
            this.PlayedTime = "00:00:00";
        }
    }
}