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
    }

    public static class GameState
    {
        public static List<string> PlayerNames = new List<string>() { "fero","ernest"};
    }
}