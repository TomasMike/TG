using System.ComponentModel;
using System.Xml.Serialization;
using TG.CustomControls;
using TG.Enums;
using TG.HelpersUtils;

namespace TG.PlayerCharacterItems
{
    [DefaultBindingProperty("PlayerNumber")]
    public class Player
    {
        public PlayerNumber PlayerNumber { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
        public int CurrentLocation { get; set; }

        [XmlIgnore]
        public LocationCardControl CurrentLocationCard => LocationsHelper.GetLCControlFromLocationNumber(CurrentLocation);

        //public List<Card> Hand;
        //public List<Card> DrawingDeck;
        //public List<Card> DiscardPile;
    }
}