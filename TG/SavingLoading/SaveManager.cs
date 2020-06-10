using System;
using System.Xml.Serialization;

namespace TG
{
    public static class SaveManager
    {
        public static void Save()
        {
            XmlSerializer x = new XmlSerializer(typeof(SaveSheet));
            x.Serialize(Console.Out, Game.CurrentSaveSheet);
        }
    }
}