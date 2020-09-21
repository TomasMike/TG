using System;
using System.Collections.Generic;

namespace TG.Exploration
{
    /// <summary>
    /// represents the whole text structure for each location
    /// </summary>
    public class ExplorationScenario
    {
        public ScenarioParagraph IntroParagrapth;

        /// <summary>
        /// represents all paragraphs in the exploration section of one location, key is the number of the paragraph 
        /// </summary>
        public Dictionary<int, ScenarioParagraph> Options;
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