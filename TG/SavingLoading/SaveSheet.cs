using System.Collections.Generic;

namespace TG
{
    public class SaveSheet
    {
        public string fileName;
        public List<Player> Players;

        public SaveSheet()
        {
            Players = new List<Player>();
        }
    }
}