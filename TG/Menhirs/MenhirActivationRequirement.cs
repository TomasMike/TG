using System;
using System.Collections.Generic;

namespace TG.Menhirs
{
    public class MenhirActivationRequirement
    {
        public Dictionary<MenhirActivationRequirementsResourceEnum, int> PerCharacterCosts;
        public List<string> RequiredItems = new List<string>();
        public List<string> RequiredSecrets = new List<string>();
    }

    public enum MenhirActivationRequirementsResourceEnum
    {
        Energy,
        Health,
        Wealth,
        Magic,
        Food,
    }
}
