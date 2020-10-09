using System;
using System.Collections.Generic;
using TG.Enums;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ParagraphAction
    {
        /// <summary>
        /// -1 means exploration ends, 0 is location intro, null is when redirect paragraph is not set
        /// </summary>
        public int? ParagraphNumToRedirectToAfter;
    }

    public class PayResourcesParagrapthAction : ParagraphAction
    {
        public IEnumerable<Tuple<CharacterResourceType, int>>[] PaymentOptions;
    }

    public class EffectParagraphAction : ParagraphAction
    {
        public Action<ExplorationEventArgs> Action;
    }

    #region other

    public enum AfterParagraphOptionAction
    {
        GoToIntroParagraph,
        EndExploration,
        RedirectToDifferentParagraph,
    }
    #endregion
}