using System.Collections.Generic;
using TG.Forms;
using System.Linq;
using TG.PlayerCharacterItems;
using TG.HelpersUtils;
using TG.SavingLoading.SaveModels;
using TG.CoreStuff;

namespace TG.SavingLoading
{
    public class SaveSheet
    {
        public string fileName;
        public List<PlayerSaveModel> Players;
        public List<LocationSaveObject> Locations;
        public SerializableDictionary<string, string> Statuses;

        public SaveSheet()
        {
            Players = new List<PlayerSaveModel>();
            Locations = new List<LocationSaveObject>();
            Statuses = new SerializableDictionary<string, string>();
        }

        public void SaveGameDataToSaveSheet()
        {
            Locations = _MainForm.Instance.Mp.LocationCards
                .Select(
                    _ => new LocationSaveObject()
                    {
                        MenhirValue = _.MenhirValue,
                        LocationNumber = _.LocationNumber
                    })
                .ToList();

            Players = Game.Instance.Players.Select(_ => _.GetAsSaveSheetObject()).ToList();
        }
    }

    public class LocationSaveObject
    {
        public int MenhirValue;
        public int LocationNumber;
    }
}