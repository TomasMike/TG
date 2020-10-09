using System;
using System.Collections.Generic;
using TG.PlayerDecisionIO;

namespace TG.Exploration
{
    public class ScenarioParagraph : IAskerOption
    {
        /// <summary>
        /// initial option text,
        /// </summary>
        public string Text;

        public string AdditionalText;

        /// <summary>
        /// each options in this paragraph, they contain logic for their availability, if null there are no choices, the effects are applied and then the party is redirected forward
        /// </summary>
        public List<ParagraphOption> ParagraphOptions;

        /// <summary>
        /// checks for if the party is forced to pick certain option
        /// </summary>
        public List<ForcedOption> ForcedOptions;

        /// <summary>
        /// possible effect that is applied always and before the paragraph choice is available
        /// </summary>
        public ParagraphAction PreParagraphChoiceEffect;


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

    public class CheckForcedOptionResult
    {
        public int ReturnValue;
        public CheckForcedOptionResultAction Action;
    }

    public enum CheckForcedOptionResultAction
    {
        None,
        ChangeLocationStateAndForceNewLocationExporationAction,
        //ForceNewLocationExporationAction,
        ForceScenarioParagraph
    }

    public abstract class ForcedOption : IAskerOption
    {
        public Func<object, bool> Check;
        public string PossesionReason;
        public abstract string GetDescription();

        public string GetOptionDescription()
        {
            throw new NotImplementedException();
        }
    }

    public class ForceScenarioParagraphForcedOption : ForcedOption
    {
        public int RedirectToParagraphNum;

        public override string GetDescription()
        {
            return $"You have {PossesionReason}, therefore you are forced to choose paragraph {RedirectToParagraphNum}.";
        }
    }

    public class ChangeLocationStateForcedOption : ForcedOption
    {
        public int OldLocationNumber;
        public int NewLocationNumber;

        public override string GetDescription()
        {
            return $"You have {PossesionReason}, therefore this location [{OldLocationNumber}] is put to alternate state [{NewLocationNumber}] and exploration continues there.";
        }
    }
}