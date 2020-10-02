using System;
using System.Collections.Generic;
using TG.Enums;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ParagraphOption :IAskerOption<ParagraphOption>
    {
        
        public string MainText;
        public string OtherText;
        
        public string ActionEffectDescription;
        
 
        /// <summary>
        /// if null, return to location intro
        /// </summary>
        public ParagraphAction ParagraphAction;



        public string GetOptionDescription()
        {
            throw new NotImplementedException();
        }

        public ParagraphOption GetOptionObject()
        {
            throw new NotImplementedException();
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