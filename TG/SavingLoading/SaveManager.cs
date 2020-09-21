using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using TG.CoreStuff;
using TG.Forms;
using TG.HelpersUtils;
using TG.PlayerCharacterItems;

namespace TG.SavingLoading
{
    public static class SaveManager
    {
        public static string SaveFolder;
        public static SaveSheet CurrentSaveSheet;


        static SaveManager()
        {
            SaveFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\SaveFiles"));
            if (string.IsNullOrEmpty(SaveFolder))
                throw new Exception("muset setup savefolder in appsettings");
        }


        /// <summary>
        /// creates new save file and sets current save sheet to it
        /// </summary>
        /// <param name="fileName"></param>
        public static void SaveAs(string fileName)
        {
            CurrentSaveSheet = new SaveSheet { fileName = fileName };
        }

        public static void Save(bool firstTimeSaveToFile = false)
        {
            if (CurrentSaveSheet == null)
                throw new Exception("current save sheet is empty, wft?");

            CurrentSaveSheet.SaveGameDataToSaveSheet();

            XmlSerializer writer = new XmlSerializer(typeof(SaveSheet));
            var path = Path.Combine(SaveFolder, CurrentSaveSheet.fileName + ".xml");
            FileStream file = File.Create(path);
            writer.Serialize(file, CurrentSaveSheet);
            file.Close();
        }

        public static void Load(string path)
        {
            if (CurrentSaveSheet != null)
                throw new Exception("current save sheet isntempty, wft?");

            var serializer = new XmlSerializer(typeof(SaveSheet));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                TextReader reader = new StreamReader(fs);
                CurrentSaveSheet = (SaveSheet)serializer.Deserialize(reader);
            }
        }

        public static void LoadGameDataFromSaveFile()
        {

            //TODO init ine herne komponenty
            foreach (var l in CurrentSaveSheet.Locations)
            {
                _MainForm.Instance.Mp.AddLocationCardToMap(l.LocationNumber, l.MenhirValue);
            }

            Game.Instance.Players.Clear();
            //_characterPanelFlPanel.SuspendLayout();
            foreach (var p in CurrentSaveSheet.Players)
            {
                Game.Instance.Players.Add(new Player(p));
            }
        }
    }
}