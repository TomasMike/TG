using System;
using System.Collections.Generic;

namespace TG.Menhirs
{
    public class MenhirActivationRequirement
    {
        public Dictionary<string, int> PerCharacterCosts;
        public List<string> RequiredItems;
        public List<int> RequiredSecrets;
    }
}
