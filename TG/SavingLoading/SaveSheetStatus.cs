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

    public class SaveSheetStatus
    {
        public int[] ObtainedParts;

        public SaveSheetStatus() { }

        public SaveSheetStatus(int statusParts)
        {
            ObtainedParts = new int[statusParts];
        }

        /// <summary>
        /// For statuses with single part
        /// </summary>
        /// <returns></returns>
        public bool IsStatusObtained()
        {
            if (ObtainedParts.Length > 1)
                throw new Exception("Tento status ma viac casti, spytaj sa na konkretny.");

            return ObtainedParts[0] == 1;
        }

        public bool IsStatusObtained(int partNumber)
        {
            if(partNumber > ObtainedParts.Length)
                throw new Exception($"Tento status ma {ObtainedParts.Length} casti, ale pytas sa na {partNumber}.");

            return ObtainedParts[partNumber - 1] == 1;
        }

    }
}