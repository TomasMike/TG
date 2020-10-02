using System;
using System.Collections.Generic;
using TG.Enums;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ParagraphAction
    {
        /// <summary>
        /// -1 means exploration ends, 0 is location intro
        /// </summary>
        public int ParagraphNumToRedirectToAfter;
    }

    public class ConditionalParagrapthAction : ParagraphAction, IConditionalParagraphAction
    {
        public bool ActionCondition(ExplorationEventArgs args)
        {
            return Condition(args);
        }

        public Func<ExplorationEventArgs, bool> Condition;
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
    public interface IConditionalParagraphAction
    {
        bool ActionCondition(ExplorationEventArgs args);
    }

    public enum AfterParagraphOptionAction
    {
        GoToIntroParagraph,
        EndExploration,
        RedirectToDifferentParagraph,
    }

    #endregion
}