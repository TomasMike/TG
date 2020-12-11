using System;
using System.Security.AccessControl;
using TG.Enums;
using TG.PlayerCharacterItems;

namespace TG.HelpersUtils
{
    public static class CharacterHelper
    {
        public static bool HasCharacterSecretByNumber(this Character ch, int secretNumber)
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

        public static bool HasCharacterSecretByName(this Character ch, string secretName)
        {
            foreach (var item in ch.Items)
            {
                if (item is SecretItem && ((SecretItem)item).Name == secretName)
                {
                    return true;
                }
            }

            return false;
        }

        public static int GetCharactersResourceAmount(this Character ch, CharacterResourceType res)
        {
            throw new NotImplementedException();
        }
    }
}