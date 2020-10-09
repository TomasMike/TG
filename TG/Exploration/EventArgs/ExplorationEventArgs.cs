using System.Collections.Generic;
using TG.CustomControls;
using TG.PlayerCharacterItems;

namespace TG.Exploration
{
    public class ExplorationEventArgs
    {
        public LocationCardControl LocationOfExploration;
        public List<Player> ActiveParty;
    }

    public class DreamNightmareEventArgs
    {
        public Player Player;
    }


}