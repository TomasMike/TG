using System;
using System.Collections.Generic;
using TG.PlayerCharacterItems;

namespace TG.Exploration
{
    /// <summary>
    /// represents the whole text structure for each location
    /// </summary>
    public class ExplorationScenario
    {
        /// <summary>
        /// the intro paragrapth that the exploration starts in
        /// </summary>
        public ScenarioParagraph IntroParagraph;

        /// <summary>
        /// represents all paragraphs in the exploration section of one location, key is the number of the paragraph 
        /// </summary>
        public List<ScenarioParagraph> Options;

        public DreamNightmareParagraph Dream;
        public DreamNightmareParagraph Nightmare;
    }
}