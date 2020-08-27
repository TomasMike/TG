using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TG.Enums;
using TG.Forms;
using TG.PlayerCharacterItems;
using TG.PlayerDecisionIO;
using TG.SavingLoading;

namespace TG.CoreStuff
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

        public Player ActivePlayer => Players.First(_ => _.PlayerNumber == ActivePlayerNumber);
        public List<Player> Players = new List<Player>();
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
        private List<PlayerNumber> playersWhoPassedThisDay = new List<PlayerNumber>();

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
            if (playersWhoPassedThisDay.Count == Players.Count())
                EndOfDay();
            else
            {
                if (Players.Count > 1)
                {
                    var playersWhoDidntActThisRound = Players.Select(_ => _.PlayerNumber).ToList();
                    playersWhoDidntActThisRound.RemoveAll(_ => playersWhoActedThisRound.Contains(_));
                    playersWhoDidntActThisRound.RemoveAll(_ => playersWhoPassedThisDay.Contains(_));

                    if (playersWhoPassedThisDay.Count == 0)
                    {
                        //next round
                        playersWhoDidntActThisRound.Clear();
                        DuringDay();
                    }
                    else
                    {
                        var reply = Asker.Ask("Who will be next active player?", playersWhoDidntActThisRound.Select(_ => new Option<PlayerNumber>(_)), false).GetOptionObject();
                        Instance.ActivePlayerNumber = reply;
                        _MainForm.Instance.Text = $"Active Player:{Instance.ActivePlayer.Name}";
                    }
                }
                else
                {
                    //singleplayer
                    Instance.ActivePlayerNumber = PlayerNumber.Player1;
                }
            }
        }

        public void StartNextPlayerTurn()
        {
            playersWhoActedThisRound.Add(Instance.ActivePlayerNumber);
            DuringDay();
            //enable/disable available action buttons
        }
        public void PlayerPassed()
        {
            playersWhoPassedThisDay.Add(Instance.ActivePlayerNumber);
        }


        public void EndOfDay()
        {
            #region Rest Step

            foreach (var player in Players)
            {
                var playerHasEaten = player.Character.Food >= 1 && MessageBox.Show($"{player.Name} eats?", "Rest", MessageBoxButtons.YesNo) == DialogResult.Yes;
                if(playerHasEaten)
                {
                    player.Character.EditCharProperty(CharacterAttribute.Food, EditCharPropertyChangeType.Subtract, 1);
                    player.Character.EditCharProperty(CharacterAttribute.CurrentHealth, EditCharPropertyChangeType.Add, 1);
                    player.Character.EditCharProperty(CharacterAttribute.CurrentTerror, EditCharPropertyChangeType.Subtract, 1);
                }
                else
                {
                    if(player.Character.CurrentEnergy == 0)
                    {
                        player.Character.EditCharProperty(CharacterAttribute.CurrentHealth, EditCharPropertyChangeType.Subtract, 1);
                    }
                    else
                        player.Character.EditCharProperty(CharacterAttribute.CurrentEnergy, EditCharPropertyChangeType.ToZero);
                }
            }
            #endregion

            #region Restore Energy

            #endregion
            ProcessMorningStuff();
        }
    }
}