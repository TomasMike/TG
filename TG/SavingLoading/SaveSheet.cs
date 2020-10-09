using System.Collections.Generic;
using TG.Forms;
using System.Linq;
using TG.PlayerCharacterItems;
using TG.HelpersUtils;
using TG.SavingLoading.SaveModels;
using TG.CoreStuff;
using System.Windows.Forms;
using System;

namespace TG.SavingLoading
{
    public class SaveSheet
    {
        public string fileName;
        public List<PlayerSaveModel> Players;
        public List<LocationSaveObject> Locations;
        public SerializableDictionary<string, SaveSheetStatus> Statuses;

        public SaveSheet()
        {
            Players = new List<PlayerSaveModel>();
            Locations = new List<LocationSaveObject>();
            InitNewSaveSheetStatuses();
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

        public bool CheckStatus(string name, int statusPart = 1)
        {
            try
            {
                return Statuses[name].IsStatusObtained(statusPart);
            }
            catch (KeyNotFoundException e)
            {
                MessageBox.Show("that status doesnt exist");
                throw e;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public void GainStatus(string name, int statusPart = 1)
        {
            //TODO tu zobrazit aky status bol ziskany
            //                         MessageBox.Show("Gain 1 of the \"Fate of the Expedition\".");
            Statuses[name].ObtainedParts[statusPart] = 1;
        }

        private void InitNewSaveSheetStatuses()
        {
            this.Statuses = new SerializableDictionary<string, SaveSheetStatus>
            {
                {"Allies of Avalon",new SaveSheetStatus(5)},
                {"Black Cauldron",new SaveSheetStatus(3)},
                {"Burning Mystery",new SaveSheetStatus(8)},
                {"Call from Beyond",new SaveSheetStatus(1)},
                {"Charred Knowledge",new SaveSheetStatus(1)},
                {"Cherished Belongings",new SaveSheetStatus(1)},
                {"Cold Pyre",new SaveSheetStatus(1)},
                {"Cosuil",new SaveSheetStatus(5)},
                {"Deal Breaker",new SaveSheetStatus(1)},
                {"Deep Secret",new SaveSheetStatus(1)},
                {"Diplomat",new SaveSheetStatus(3)},
                {"Diplomatic Mission",new SaveSheetStatus(6)},
                {"Disturbing Information",new SaveSheetStatus(3)},
                {"Dreams and Prophecies",new SaveSheetStatus(8)},
                {"End of the Road",new SaveSheetStatus(1)},
                {"Enemies of Avalon",new SaveSheetStatus(3)},
                {"Escalation",new SaveSheetStatus(3)},
                {"Fael's Legacy",new SaveSheetStatus(1)},
                {"Fall of Chivalry",new SaveSheetStatus(8)},
                {"Farpoint Clues",new SaveSheetStatus(5)},
                {"Fate of the Expedition",new SaveSheetStatus(9)},
                {"Final Confrontations",new SaveSheetStatus(7)},
                {"Final Lesson",new SaveSheetStatus(5)},
                {"Fortunate Meetings",new SaveSheetStatus(5)},
                {"General Directions",new SaveSheetStatus(1)},
                {"Gerraint's Successor",new SaveSheetStatus(3)},
                {"Glen Ritual",new SaveSheetStatus(2)},
                {"Guest of Honor",new SaveSheetStatus(1)},
                {"Halfway Intrigue",new SaveSheetStatus(3)},
                {"Helping Hand",new SaveSheetStatus(6)},
                {"Helping the Knights",new SaveSheetStatus(4)},//na sheete su 4 prazdne policka
                {"Hidden Treasures",new SaveSheetStatus(8)},
                {"Hunter's Mark",new SaveSheetStatus(1)},
                {"Lady's Task",new SaveSheetStatus(1)},
                {"Last Haven",new SaveSheetStatus(5)},
                {"Left Behind",new SaveSheetStatus(9)},
                {"Lost and Fallen",new SaveSheetStatus(7)},
                {"Maggot's Redemption",new SaveSheetStatus(1)},
                {"Matricide",new SaveSheetStatus(1)},
                {"Monastery Discovered",new SaveSheetStatus(1)},
                {"Moonring Mission",new SaveSheetStatus(1)},
                {"Morgaine's Task",new SaveSheetStatus(1)},
                {"Mourning Song",new SaveSheetStatus(2)},
                {"Mystery Solved",new SaveSheetStatus(1)},
                {"Pathfinder",new SaveSheetStatus(8)},
                {"Peace in Borough",new SaveSheetStatus(1)},
                {"People's Champion",new SaveSheetStatus(1)},
                {"Pillager",new SaveSheetStatus(5)},
                {"Reclamation",new SaveSheetStatus(1)},
                {"Remedy",new SaveSheetStatus(4)},
                {"Remnants",new SaveSheetStatus(5)},
                {"Restoring the Order",new SaveSheetStatus(8)},
                {"Riddle of the Oldsteel",new SaveSheetStatus(1)},
                {"Saved by the Goddess",new SaveSheetStatus(1)},
                {"Scrounger",new SaveSheetStatus(1)},
                {"Secrets of the Forest",new SaveSheetStatus(4)},
                {"Shelter in the Storm",new SaveSheetStatus(1)},
                {"Shrine Secure",new SaveSheetStatus(1)},
                {"Something is Watching",new SaveSheetStatus(1)},//v sheete su 4 prazdne policka
                {"Stonemason's Secret",new SaveSheetStatus(1)},
                {"Strange Encounters",new SaveSheetStatus(8)},
                {"Supplying the Revolt",new SaveSheetStatus(4)},//v sheete su 4 prazdne policka
                {"Tangleroot Knowledge",new SaveSheetStatus(2)},
                {"Tracker",new SaveSheetStatus(1)},
                {"Traveling Menhir",new SaveSheetStatus(2)},
                {"Tuathan Exploration",new SaveSheetStatus(5)},
                {"Underfern",new SaveSheetStatus(5)},
                {"War for Avalon",new SaveSheetStatus(4)},
                {"Winds of Wyrdness",new SaveSheetStatus(1)},
            };
        }
    }


}