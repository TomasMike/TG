using System.Collections.Generic;
using TG.Exploration;
using TG.SavingLoading;

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
                            ExplorationIntroText = "A deep feeling of loss fills everyhing in Cuanacht - from dilapidated farms to the sunken eyes of those who remain in town. The menhir in the market is all but extinguished and everyone brave or resourceful enough has left to find a solution.",
                            CheckForcedOption = o => 
                            {
                                var retVal = new CheckForcedOptionResult();

                                if(SaveManager.CurrentSaveSheet.Statuses.ContainsKey("Winds of Wyrdness"))
                                {
                                    retVal.Action = CheckForcedOptionResultAction.ChangeLocationStateAndForceNewLocationExporationAction;
                                    retVal.ReturnValue = 121;
                                }
                                else if(Game.Instance.ActivePlayer)
                                {

                                }



                            }
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