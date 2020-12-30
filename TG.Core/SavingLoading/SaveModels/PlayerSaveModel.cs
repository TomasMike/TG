namespace TG.Core.SavingLoading.SaveModels
{
    public class PlayerSaveModel
    {
        public PlayerNumber PlayerNumber;
        public string Name;
        public int CurrentLocation;
        public CharacterName CharacterName;
        public CharacterArchetype Archetype;

        public int Aggression;
        public int Courage;
        public int Practicality;
        public int Empathy;
        public int Caution;
        public int Spirituality;

        public int MaxHealth;
        public int CurrentHealth;
        public int MaxEnergy;
        public int CurrentEnergy;
        public int MaxTerror;
        public int CurrentTerror;

        public int Food;
        public int Reputation;
        public int Wealth;
        public int Experience;
        public int Magic;
    }
}
