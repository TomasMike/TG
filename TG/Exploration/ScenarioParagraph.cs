using System.Collections.Generic;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ScenarioParagraph : IAskerOption<ScenarioParagraph>
    {
        public string Text;
        public Dictionary<int, ParagraphOption> ParagraphOptions;
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