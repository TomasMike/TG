using TG.PlayerCharacterItems;

namespace TG.CoreStuff
{
    public static class DebugCheats
    {
        public static bool IgnoreMenhirVicinityWhenShowNewLocationAfterTravel = false;




        public static void RestoreEnergyToActivePlayer()
        {
            Game.Instance.ActivePlayer.Character.EditCharProperty(CharacterAttribute.CurrentEnergy,EditCharPropertyChangeType.ToMax);
        }
        public static void Add10FoodToActivePlayer()
        {
            Game.Instance.ActivePlayer.Character.EditCharProperty(CharacterAttribute.Food, EditCharPropertyChangeType.Add,10);
        }
    }
}