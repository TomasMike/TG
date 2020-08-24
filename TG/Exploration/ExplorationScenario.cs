using System;
using System.Collections.Generic;

namespace TG.Exploration
{
    /// <summary>
    /// represents the whole text structure for each location
    /// </summary>
    public class ExplorationScenario
    {
        public string ExplorationIntroText;
        public Dictionary<int, ScenarioParagraph> Options;
        public Func<object, CheckForcedOptionResult> CheckForcedOption;
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
}