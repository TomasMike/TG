﻿using System;
using System.Windows.Forms;
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
                    retVal.CurrentEnergy = 6;
                    retVal.MaxEnergy = 6;
                    retVal.CurrentHealth = 9;
                    retVal.MaxHealth= 9;
                    retVal.CurrentTerror = 0;
                    retVal.MaxTerror = 6;
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