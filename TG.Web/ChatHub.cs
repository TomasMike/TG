using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TG.Web
{
    public class ChatHub : Hub
    {
        public void LetsChat(string Cl_Name, string Cl_Message)
        {
            Clients.All.NewMessage(Cl_Name, Cl_Message);
        }

        public void PlayerJoined(string name)
        {
            GameState.Instance.PlayerNames.Add(name);
            Clients.All.RefreshPlayerNamesList(GameState.Instance.PlayerNames);
        }
    }

    public sealed class GameState
    {
        #region Singleton Logic

        private static GameState instance = null;

        private GameState()
        { }

        public static GameState Instance => instance ?? (instance = new GameState());

        #endregion Singleton Logic

        public List<string> PlayerNames = new List<string>();
    }
}