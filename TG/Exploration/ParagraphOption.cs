using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TG.Enums;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ParagraphOption :IAskerOption
    {
        public string MainText;
        public string OtherText;
        public string ActionEffectDescription;
 
        /// <summary>
        /// if null, return to location intro
        /// </summary>
        public ParagraphAction ParagraphAction;

        public Func<ExplorationEventArgs, bool> OptionCondition;

        public string GetOptionDescription()
        {
            return MainText +
                (string.IsNullOrEmpty(OtherText) ? string.Empty : "\r\n" + OtherText) +
                (string.IsNullOrEmpty(ActionEffectDescription) ? string.Empty : "\r\n" + ActionEffectDescription);
        }
    }

    public class BackToIntroParagraphOption: ParagraphOption
    {
        public BackToIntroParagraphOption()
        {
            MainText = "Leave";
            ParagraphAction = new ParagraphAction { ParagraphNumToRedirectToAfter = 0 };
        }
    }
    public class ExplorationEndsParagraphOption : ParagraphOption
    {
        public ExplorationEndsParagraphOption()
        {
            MainText = "Leave";
            ParagraphAction = new ParagraphAction { ParagraphNumToRedirectToAfter = -1 };
        }
    }
}