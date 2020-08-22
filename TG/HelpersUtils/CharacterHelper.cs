using TG.PlayerCharacterItems;

namespace TG.HelpersUtils
{
    public static class CharacterHelper
    {
        public static bool HasCharacterSecret(this Character ch, int secretNumber)
        {
            foreach (var item in ch.Items)
            {
                if(item is SecretItem && ((SecretItem)item).SecretNumber == secretNumber)
                {
                    return true;
                }
            }

            return false;
        }
    }
}