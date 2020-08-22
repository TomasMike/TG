using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG.Menhirs
{
    public class MenhirActivationRequirement
    {
        public Dictionary<string, int> PerCharacterCosts;
        public List<string> RequiredItems;
        public List<int> RequiredSecrets;
    }
}
