using System.ComponentModel;
using System.Xml.Serialization;
using TG.CustomControls;
using TG.Enums;
using TG.HelpersUtils;
using TG.SavingLoading.SaveModels;

namespace TG.PlayerCharacterItems
{
    [DefaultBindingProperty("PlayerNumber")]
    public class Player
    {
        public Player() { }

        public Player(PlayerSaveModel psm)
        {
            Character = new Character(
                psm.CharacterName,
                psm.Archetype,
                psm.Aggression,
                psm.Courage,
                psm.Practicality,
                psm.Empathy,
                psm.Caution,
                psm.Spirituality,
                psm.MaxHealth,
                psm.CurrentHealth,
                psm.MaxEnergy,
                psm.CurrentEnergy,
                psm.MaxTerror,
                psm.CurrentTerror,
                psm.Food,
                psm.Reputation,
                psm.Wealth,
                psm.Experience,
                psm.Magic
            );

            PlayerNumber = psm.PlayerNumber;
            Name = psm.Name;
            CurrentLocation = psm.CurrentLocation;
        }

        public PlayerNumber PlayerNumber { get; set; }
        
        public string Name { get; set; }
        
        public Character Character { get; set; }
        
        public int CurrentLocation { get; set; }

        [XmlIgnore]
        public LocationCardControl CurrentLocationCard => LocationsHelper.GetLCControl(CurrentLocation);

        //public List<Card> Hand;
        //public List<Card> DrawingDeck;
        //public List<Card> DiscardPile;

        public PlayerSaveModel GetAsSaveSheetObject()
        {
            return new PlayerSaveModel
            {
                CharacterName = Character.CharacterName,
                Archetype = Character.Archetype,
                Aggression = Character.Aggression,
                Courage = Character.Courage,
                Practicality = Character.Practicality,
                Empathy = Character.Empathy,
                Caution = Character.Caution,
                Spirituality = Character.Spirituality,
                MaxHealth = Character.MaxHealth,
                CurrentHealth = Character.CurrentHealth,
                MaxEnergy = Character.MaxEnergy,
                CurrentEnergy = Character.CurrentEnergy,
                MaxTerror = Character.MaxTerror,
                CurrentTerror = Character.CurrentTerror,
                Food = Character.Food,
                Reputation = Character.Reputation,
                Wealth = Character.Wealth,
                Experience = Character.Experience,
                Magic = Character.Magic,
                CurrentLocation = CurrentLocation,
                Name = Name,
                PlayerNumber = PlayerNumber
            };
        }
    }
}