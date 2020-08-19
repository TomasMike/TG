using System;

namespace TG.Exploration
{
    public class ParagraphOption
    {
        
        public string Text;
        
        public string ActionEffectDescription;
        
        /// <summary>
        /// if null, this action is allways available
        /// </summary>
        public Func<ExplorationEventArgs, bool> ActionCondition;
        
        /// <summary>
        /// if null, return to location intro
        /// </summary>
        public Action<ExplorationEventArgs> ParagraphAction;
    }
}