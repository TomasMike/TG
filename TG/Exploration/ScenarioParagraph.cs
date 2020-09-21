using System;
using System.Collections.Generic;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ScenarioParagraph : IAskerOption<ScenarioParagraph>
    {
        /// <summary>
        /// initial option text,
        /// </summary>
        public string Text;

        public string AdditionalText;

        /// <summary>
        /// each options in this paragraph, they contain logic for their availability
        /// </summary>
        public List<ParagraphOption> ParagraphOptions;

        /// <summary>
        /// checks for if the party is forced to pick certain option
        /// </summary>
        public Func<object, CheckForcedOptionResult> CheckForcedOption;

        public int VerseNumber;

        public string GetOptionDescription()
        {
            return string.Empty;//todo
        }

        public ScenarioParagraph GetOptionObject()
        {
            return this;
        }
    }

 
}