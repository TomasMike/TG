using System.Collections.Generic;
using System.Linq;
using TG.Enums;
using TG.Forms;
using TG.PlayerCharacterItems;
using TG.PlayerDecisionIO;
using TG.SavingLoading;

namespace TG
{
    public sealed class Game
    {
        #region Singleton Logic

        private static Game instance = null;

        private Game()
        { }

        public static Game Instance => instance ?? (instance = new Game());

        #endregion Singleton Logic

        public static SaveSheet CurrentSaveSheet;

        private static PlayerNumber _activePlayerNumber;

        public Player ActivePlayer => SaveManager.CurrentSaveSheet.Players.First(_ => _.PlayerNumber == ActivePlayerNumber);

        public PlayerNumber ActivePlayerNumber
        {
            get { return _activePlayerNumber; }
            set
            {
                _activePlayerNumber = value;
                _MainForm.Instance.Refresh();
            }
        }

        private List<PlayerNumber> playersWhoActedThisRound = new List<PlayerNumber>();

        /// <summary>
        /// StartOfTheDay
        /// </summary>
        public void ProcessMorningStuff()
        {
            //Remove expired menhirs
            //remove locations out of the menhir range
            //reduce menhir dial and remove time tokens
            //reveal and read new event card
            //move guardians
            //change equip

            DuringDay();
        }

        public void DuringDay()
        {
            if (SaveManager.CurrentSaveSheet.Players.Count > 1)
            {
                var playersWhoDidntActThisRound = SaveManager.CurrentSaveSheet.Players.Select(_ => _.PlayerNumber).ToList();
                playersWhoDidntActThisRound.RemoveAll(_ => playersWhoActedThisRound.Contains(_));

                if(playersWhoActedThisRound.Count == 0)
                {
                    //next round
                    playersWhoActedThisRound.Clear();

                }
                else
                {
                    var reply = Asker.Ask("Who will be next active player?", playersWhoDidntActThisRound.Select(_ => new Option<PlayerNumber>(_)), false).GetOptionObject();
                    Game.Instance.ActivePlayerNumber = reply;

                }
            }
            else
            {
                //singleplayer
                Game.Instance.ActivePlayerNumber = PlayerNumber.Player1;
            }

            StartNextPlayerTurn();
        }

        public void StartNextPlayerTurn()
        {
            //enable/disable available action buttons
        }

        public void EndOfDay()
        {
        }
    }

    public enum ActionType
    {
        Explore,
        Travel,
        LocationAction,
        CharacterAction,
        InspectMenhir,
        Pass,
        Other
        //Items,Skills,Secrets
    }
}