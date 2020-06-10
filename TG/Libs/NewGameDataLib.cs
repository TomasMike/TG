using System;
using TG.Enums;

namespace TG.Forms
{
    public static class NewGameDataLib
    {
        public static Character GetStartingCharacter(CharacterName cn,CharacterArchetype ca)
        {
            if (
                (cn == CharacterName.Beor && ca != CharacterArchetype.Blue)
                || (cn == CharacterName.Arev && ca != CharacterArchetype.Gray)
                || (cn == CharacterName.Maggot && ca != CharacterArchetype.Brown)
                || (cn == CharacterName.Ailei && ca != CharacterArchetype.Green)
            )
            {
                throw  new Exception("This character/archetype combination is not allowed.");
            }

            var retVal = new Character();
            switch (cn)
            {
                case CharacterName.Beor:
                    retVal.CharacterName = CharacterName.Beor;
                    retVal.Bear = 2;
                    //....
                    break;
                default: throw new Exception("character not setupped.");
            }

            retVal.Archetype = ca;

            switch (ca)
            {
                case CharacterArchetype.Blue:
                    //setup starting health/energy/max terror, starting/advancement combat/dilpomacy decks and so
                    break;
                default: throw new Exception("archetype not setupped.");
            }

            return retVal;
        }
    }
}