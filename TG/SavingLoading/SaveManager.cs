﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

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

        public static void Save(bool firstTimeSaveToFile = false)
        {
            if (CurrentSaveSheet == null)
                throw new Exception("current save sheet is empty, wft?");

            if(!firstTimeSaveToFile)
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
    }


}