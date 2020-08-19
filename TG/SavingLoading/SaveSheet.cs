using System.Collections.Generic;
using TG.Forms;
using System.Linq;

namespace TG.SavingLoading
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

        public void Save()
        {
            Locations = _MainForm.Instance.Mp.LocationCards
                .Select(
                    _ => new LocationSaveObject()
                    {
                        MenhirValue = _.MenhirValue,
                        LocationNumber = _.LocationNumber
                    })
                .ToList();
        }
    }

    public class LocationSaveObject
    {
        public int MenhirValue;
        public int LocationNumber;
    }
}