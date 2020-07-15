using System.Collections.Generic;
using System.ComponentModel;
using TG.Enums;

namespace TG
{
    [DefaultBindingProperty("PlayerNumber")]
    public class Player
    {
        
        public PlayerNumber PlayerNumber { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
        public int Location { get; set; }

        //public List<Card> Hand;
        //public List<Card> DrawingDeck;
        //public List<Card> DiscardPile;
    }
}