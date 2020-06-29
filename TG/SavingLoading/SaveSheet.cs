using System.Collections.Generic;

namespace TG
{
    public class SaveSheet
    {
        public string fileName;
        public List<Player> Players;
        public List<LocationSaveObject> Locations;

        public SaveSheet()
        {
            Players = new List<Player>();
            Locations = new List<LocationSaveObject>();
        }
    }

    public class LocationSaveObject
    {
        public int MenhirValue;
        public int LocationNumber;
    }
}