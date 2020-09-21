using System;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ParagraphOption :IAskerOption<ParagraphOption>
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

        public AfterParagraphOptionAction AfterParagraphOptionAction;
        public int? ParagraphNumToRedirectTo;

        public string GetOptionDescription()
        {
            throw new NotImplementedException();
        }

        public ParagraphOption GetOptionObject()
        {
            throw new NotImplementedException();
        }
    }

    public enum AfterParagraphOptionAction
    {
        GoToIntroParagraph,
        EndExploration,
        RedirectToDifferentParagraph,
    }
}