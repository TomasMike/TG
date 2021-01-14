using System;
using System.Collections.Generic;
using TG.Core;

namespace TG.Web.Data
{
    public static class LobbyState
    {
        public static List<Tuple<string, CharacterName?, CharacterArchetype?>> LobbyPlayers = new List<Tuple<string, CharacterName?, CharacterArchetype?>>();
    }
}
