using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using TG.CoreStuff;
using TG.Enums;
using TG.PlayerCharacterItems;

namespace TG.HelpersUtils
{
    public static class PartyHelper
    {
        public static bool CanActivePartyPay(IEnumerable<Tuple<CharacterResourceType,int>>[] options)
        {
            return options.Any(o => o.All(o2 => o2.Item2 <= Game.Instance.ActiveParty.Sum(p => p.Character.GetCharactersResourceAmount(o2.Item1))));
        }
    }
}
