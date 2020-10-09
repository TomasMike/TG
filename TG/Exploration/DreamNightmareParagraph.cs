using System;
using System.Collections.Generic;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{

    public class DreamNightmareParagraph
    {
        public string Text;
        public string AdditionalText;
        public Action<DreamNightmareEventArgs> Effect;
    }

 
}