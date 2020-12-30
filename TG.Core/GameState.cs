using System.Collections.Generic;
using System.Linq;
using TG.Core.SavingLoading;

namespace TG.Core
{
    public sealed class GameState
    {
        #region Singleton Logic

        private static GameState instance = null;

        private GameState()
        { }

        public static GameState Instance => instance ?? (instance = new GameState());

        #endregion Singleton Logic

        public static SaveSheet CurrentSaveSheet;

        public int Round = 1;
        public int Day = 1;


        private static PlayerNumber _activePlayerNumber;


        public Player ActivePlayer => Players.First(_ => _.PlayerNumber == ActivePlayerNumber);
        public List<Player> ActiveParty => Players;

        public List<Player> Players = new List<Player>();
        public PlayerNumber ActivePlayerNumber
        {
            get { return _activePlayerNumber; }
            set
            {
                _activePlayerNumber = value;
            }
        }

        /// <summary>
        /// In each round, one action per player, then next round, until all passed, then next day
        /// </summary>
        private List<PlayerNumber> playersWhoActedThisRound = new List<PlayerNumber>();

        /// <summary>
        /// Players who passed cant do action this day
        /// </summary>
        private List<PlayerNumber> playersWhoPassedThisDay = new List<PlayerNumber>();

        /// <summary>
        /// StartOfTheDay
        /// </summary>
        public void ProcessMorningStuff()
        {
            //Remove expired menhirs
          //  _MainForm.Instance.LocationCardsPanel.RemoveInactiveMenhirs();

            //remove locations out of the menhir range
            //_MainForm.Instance.LocationCardsPanel.RemoveLocationsOutsideMenhirRange();

            //reduce menhir dial and remove time tokens
            //reveal and read new event card
            //move guardians
            //change equip

            playersWhoPassedThisDay.Clear();
            playersWhoActedThisRound.Clear();
           
        }

        

      

        public void PlayerPassed(Player p = null)
        {
            playersWhoPassedThisDay.Add(p?.PlayerNumber ?? Instance.ActivePlayerNumber);
        }

        
    }
}