using System.Collections.Generic;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ScenarioParagraph: IAskerOption<ScenarioParagraph>
    {
        public string Text;
        public Dictionary<int, ParagraphOption> ParagraphOptions;
    }
}