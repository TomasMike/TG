using System.Collections.Generic;
using TG.Exploration;

namespace TG.Libs
{
    public static class ExplorationScenariosLib
    {
        private static Dictionary<int, ExplorationScenario> _explorationScenarios;
        public static Dictionary<int, ExplorationScenario> ExplorationScenarios
        {
            get =>
                _explorationScenarios ?? (_explorationScenarios = new Dictionary<int, ExplorationScenario>
                {
                    {101, 
                        new ExplorationScenario
                        {
                            ExplorationIntroText = "Vitaj v meste?",
                            Options = new Dictionary<int, ScenarioParagraph>
                            {
                                {1,
                                    new ScenarioParagraph
                                    {
                                        Text = "Ist do pajzlu",
                                        ParagraphOptions = new Dictionary<int, ParagraphOption>
                                        {
                                            {1,
                                                new ParagraphOption
                                                {
                                                    Text = "Kupit si izbu a vyspat sa",
                                                    ActionEffectDescription = "-1 Wealth, +2 Energy",
                                                    ActionCondition = e => Game.Instance.ActivePlayer.Character.Wealth >= 1,
                                                    ParagraphAction  = e => 
                                                    {
                                                        Game.Instance.ActivePlayer.Character.Wealth--;
                                                        Game.Instance.ActivePlayer.Character.CurrentEnergy +=2;
                                                    }
                                                }
                                            },
                                            {2,
                                                new ParagraphOption
                                                {
                                                    Text = "Ist von na ulicu.",
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                });
            private set => _explorationScenarios = value;
        }


    }
}