using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using TG.Core;

namespace TG.Web.Data
{
    public class LobbyHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task PlayerJoined(string name)
        {
            CharacterArchetype? charch = null;
            CharacterName? chnam = null;

            foreach(CharacterArchetype a in Enum.GetValues(typeof(CharacterArchetype)))
            {
                if(LobbyState.LobbyPlayers.All(q => q.Item3.HasValue && q.Item3.Value != a))
                {
                    charch = a;
                    break;
                }
            }

            foreach (CharacterName a in Enum.GetValues(typeof(CharacterName)))
            {
                if (LobbyState.LobbyPlayers.All(q => q.Item2.HasValue && q.Item2.Value != a))
                {
                    chnam = a;
                    break;
                }
            }

            LobbyState.LobbyPlayers.Add(new Tuple<string, CharacterName?, CharacterArchetype?>(name, chnam, charch));

            await Clients.All.SendAsync("UpdatePlayerList",null);
        }
    }
}
