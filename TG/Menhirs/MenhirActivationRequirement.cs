using System;
using System.Collections.Generic;
using TG.Enums;
using TG.SavingLoading;

namespace TG.Menhirs
{
    public class MenhirActivationRequirement
    {
        /// <summary>
        /// Required state of statuses, if value is false it means that it is required to not have that status
        /// </summary>
        public Dictionary<SaveSheetStatusEnum, bool> RequiredStatuses = new Dictionary<SaveSheetStatusEnum, bool>();

        public Dictionary<MenhirActivationRequirementsResourceEnum, int> PerCharacterCosts;
        public List<string> RequiredItems = new List<string>();
        public List<string> RequiredSecretsByName = new List<string>();
        public List<int> RequiredSecretsByNumber = new List<int>();

        public bool RequiredActiveMenhirInLocation;
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
