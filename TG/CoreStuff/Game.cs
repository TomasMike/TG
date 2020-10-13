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
            playersWhoPassedThisDay.Clear();
            playersWhoActedThisRound.Clear();
            DuringDay();
        }

        public void DuringDay()
        {
            if (playersWhoPassedThisDay.Count == Players.Count)
            {
                MessageBox.Show("All players passed. Jumping to end of day phase.");
                EndOfDay();
            }
            else
            {
                if (Players.Count > 1)
                {
                    // ries kto bol toto kolo, ked vsetci zacni dalsie kolo a kto passol uz
                    var possiblePlayersToBeActivePlayer = Players.Select(_ => _.PlayerNumber).ToList();
                    possiblePlayersToBeActivePlayer.RemoveAll(_ => playersWhoActedThisRound.Contains(_));
                    possiblePlayersToBeActivePlayer.RemoveAll(_ => playersWhoPassedThisDay.Contains(_));

                    if (possiblePlayersToBeActivePlayer.Count == 0)
                    {
                        //next round
                        Round++;
                        playersWhoActedThisRound.Clear();
                        //MessageBox.Show("All players who didnt pass, acted this round. Next round starts.");
                        DuringDay();
                        return;
                    }
                    else if (possiblePlayersToBeActivePlayer.Count == 1)
                    {
                        Instance.ActivePlayerNumber = possiblePlayersToBeActivePlayer[0];
                        MessageBox.Show($"{Instance.ActivePlayerNumber} is the last player who didnt act this round, hes the active player now.");
                    }
                    else
                    {
                        Instance.ActivePlayerNumber =
                            Asker.Ask(
                                "Who will be next active player?",
                                possiblePlayersToBeActivePlayer.Select(_ => new Option<PlayerNumber>(_))).InnerOption;
                    }
                    //
                }
                else
                {
                    //singleplayer
                    Instance.ActivePlayerNumber = PlayerNumber.Player1;
                    //MessageBox.Show("SinglePlayer");
                }
                _MainForm.Instance.Text = $"Active Player:{Instance.ActivePlayer.Name}";
                StartNextPlayerTurn();
            }
        }

        public void StartNextPlayerTurn()
        {
            //MessageBox.Show($"ACTIVE PLAYER:{Instance.ActivePlayerNumber}");
            playersWhoActedThisRound.Add(Instance.ActivePlayerNumber);
        }
        public void PlayerPassed(Player p = null)
        {
            playersWhoPassedThisDay.Add(p?.PlayerNumber ?? Instance.ActivePlayerNumber);
        }

        public void EndOfDay()
        {
            foreach (var player in Players)
            {
                #region Rest Step

                if (player.Character.Food >= 1 && MessageBox.Show($"{player.Name} eats?", "Rest", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    player.Character.EditCharProperty(CharacterAttribute.Food, EditCharPropertyChangeType.Subtract, 1);
                    player.Character.EditCharProperty(CharacterAttribute.CurrentHealth, EditCharPropertyChangeType.Add, 1);
                    player.Character.EditCharProperty(CharacterAttribute.CurrentTerror, EditCharPropertyChangeType.Subtract, 1);
                }
                else
                {
                    var message = "You didn't eat, therefore you loose ";
                    if (player.Character.CurrentEnergy == 0)
                    {
                        player.Character.EditCharProperty(CharacterAttribute.CurrentHealth, EditCharPropertyChangeType.Subtract, 1);
                        message += "1 Health.";
                    }
                    else
                    {
                        player.Character.EditCharProperty(CharacterAttribute.CurrentEnergy, EditCharPropertyChangeType.ToZero);
                        message += "all Energy.";
                    }
                    MessageBox.Show(message);
                }
                #endregion

                #region Restore Energy

                if (player.Character.CurrentEnergy <= 1)
                {
                    //exhausted
                    player.Character.EditCharProperty(CharacterAttribute.CurrentEnergy, EditCharPropertyChangeType.Add,4);
                }
                else
                {
                    player.Character.EditCharProperty(CharacterAttribute.CurrentEnergy, EditCharPropertyChangeType.ToMax);
                }
                #endregion

                #region Advance Character
                //TODO
                #endregion
                #region Build Character Decks
                //TODO
                #endregion
                #region Experience Dreams
                //TODO
                #endregion
            }

            ProcessMorningStuff();
        }
    }
}