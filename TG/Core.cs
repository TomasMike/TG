using System.Linq;
using TG.Enums;

namespace TG
{
    public sealed class Game
    {
        #region Singleton Logic
        private static Game instance = null;

        Game() { }

        public static Game Instance => instance ?? (instance = new Game()); 
        #endregion

        public static SaveSheet CurrentSaveSheet;

        private static PlayerNumber _activePlayerNumber;

        public Player ActivePlayer => CurrentSaveSheet.Players.First(_ => _.PlayerNumber == ActivePlayerNumber);
        public PlayerNumber ActivePlayerNumber 
        {
            get { return _activePlayerNumber; }
            set 
            { 
                _activePlayerNumber = value;
                _MainForm.Instance.Refresh();
            } 
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
