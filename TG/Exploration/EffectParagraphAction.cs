using System;
using System.Collections.Generic;
using TG.Enums;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class EffectParagraphAction
    {
        /// <summary>
        /// -1 means exploration ends, 0 is location intro, null is when redirect paragraph is not set
        /// </summary>
        public Action<ExplorationEventArgs> Action;

    }

    public class PayResourcesEffectParagraphAction : EffectParagraphAction
    {
        public IEnumerable<Tuple<CharacterResourceType, int>>[] PaymentOptions;
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