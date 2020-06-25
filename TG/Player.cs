using System.Collections.Generic;
using System.ComponentModel;

namespace TG
{
    [DefaultBindingProperty("PlayerNumber")]
    public class Player
    {
        [Bindable(BindableSupport.Yes)]
        public int PlayerNumber { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }

        //public List<Card> Hand;
        //public List<Card> DrawingDeck;
        //public List<Card> DiscardPile;
    }
}