using System;
using TG.Enums;
using TG.PlayerCharacterItems;

namespace TG.Libs
{
    public static class NewGameDataLib
    {
        public static Character GetStartingCharacter(CharacterName cn, CharacterArchetype ca)
        {
            if (
                cn == CharacterName.Beor && ca != CharacterArchetype.Blue
                || cn == CharacterName.Arev && ca != CharacterArchetype.Gray
                || cn == CharacterName.Maggot && ca != CharacterArchetype.Brown
                || cn == CharacterName.Ailei && ca != CharacterArchetype.Green
            )
            {
                throw new Exception("This character/archetype combination is not allowed.");
            }

            int agg, cou, pra, emp, cau, spi, mhp, men, mte, fod = 0, rep = 0, wea = 0, exp = 0, mag = 0;

            //starting stats+resources
            switch (cn)
            {
                case CharacterName.Beor:
                    agg = 2;
                    cou = 1;
                    pra = 1;
                    emp = 0;
                    cau = 1;
                    spi = 0;

                    fod = 2;
                    break;
                case CharacterName.Ailei:
                    agg = 0;
                    cou = 0;
                    pra = 1;
                    emp = 2;
                    cau = 1;
                    spi = 1;
                    
                    fod = 2;
                    //....
                    break;
                default: throw new Exception("character not setupped.");
            }


            switch (ca)
            {
                //setup starting health/energy/max terror, starting/advancement combat/dilpomacy decks and so
                case CharacterArchetype.Blue:
                    men = 6;
                    mhp = 9;
                    mte = 6;
                    break;
                case CharacterArchetype.Brown:
                case CharacterArchetype.Gray:
                case CharacterArchetype.Green:
                    men = 6;
                    mhp = 9;
                    mte = 6;
                    break;
                    break;
                default: throw new Exception("archetype not setupped.");
            }
            var retVal = new Character(cn,ca,agg,cou,pra,emp,cau,spi,mhp,mhp,men,men,mte,0,fod,rep,wea,exp,mag);

            return retVal;
        }
    }
}