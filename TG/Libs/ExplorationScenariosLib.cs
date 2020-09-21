using System;
using System.Collections.Generic;
using TG.CoreStuff;
using TG.Exploration;
using TG.HelpersUtils;
using TG.PlayerCharacterItems;
using TG.SavingLoading;

namespace TG.Libs
{
    public static class ExplorationScenariosLib
    {
        /// <summary>
        /// key is the location number
        /// </summary>
        private static Dictionary<int, ExplorationScenario> _explorationScenarios;
        public static Dictionary<int, ExplorationScenario> ExplorationScenarios
        {
            get =>
                _explorationScenarios ?? (_explorationScenarios = new Dictionary<int, ExplorationScenario>
                {
                    {
                        101,
                        new ExplorationScenario
                        {
                            IntroParagrapth = new ScenarioParagraph
                            {
                                Text = "A deep feeling of loss fills everyhing in Cuanacht - from dilapidated farms to the sunken eyes of those who remain in town. The menhir in the market is all but extinguished and everyone brave or resourceful enough has left to find a solution.",
                                CheckForcedOption = o =>
                                {
                                    var retVal = new CheckForcedOptionResult();

                                    if(SaveManager.CurrentSaveSheet.CheckStatus("Winds of Wyrdness"))
                                    {
                                        retVal.Action = CheckForcedOptionResultAction.ChangeLocationStateAndForceNewLocationExporationAction;
                                        retVal.ReturnValue = 121;
                                    }
                                    else if(Game.Instance.ActivePlayer.Character.HasCharacterSecret(66))
                                    {
                                        retVal.Action = CheckForcedOptionResultAction.ForceScenarioParagraph;
                                        retVal.ReturnValue = 4;
                                    }
                                    else if(SaveManager.CurrentSaveSheet.CheckStatus("Hunter's Mark"))
                                    {
                                        retVal.Action = CheckForcedOptionResultAction.ForceScenarioParagraph;
                                        retVal.ReturnValue = 6;
                                    }
                                    return retVal;
                                },
                                ParagraphOptions = new List<ParagraphOption>
                                {
                                    new ParagraphOption
                                    {
                                        Text = "Visit the families of the champions from the first expedition - If you're to find them, knowing more about them might help.",
                                        AfterParagraphOptionAction = AfterParagraphOptionAction.RedirectToDifferentParagraph,
                                        ParagraphNumToRedirectTo = 1,
                                    },
                                    new ParagraphOption
                                    {
                                        Text = "Ask the townsfolk to help you prepare",
                                        AfterParagraphOptionAction = AfterParagraphOptionAction.RedirectToDifferentParagraph,
                                        ParagraphNumToRedirectTo = 3,
                                    },
                                    new ParagraphOption
                                    {
                                        Text = "Rest for the day in your own home",
                                        AfterParagraphOptionAction = AfterParagraphOptionAction.RedirectToDifferentParagraph,
                                        ParagraphNumToRedirectTo = 5,
                                    },
                                    new ParagraphOption
                                    {
                                        Text = "Wander the alleys twisted by the wyrdness",
                                        ActionCondition = (e) =>  e.LocationOfExploration.MenhirValue == -1 ,
                                        AfterParagraphOptionAction = AfterParagraphOptionAction.RedirectToDifferentParagraph,
                                        ParagraphNumToRedirectTo = 9,
                                    },
                                    new ParagraphOption
                                    {
                                        Text = "Leave",
                                        AfterParagraphOptionAction = AfterParagraphOptionAction.EndExploration,
                                    }
                                
                                }
                            },
                            Options = new Dictionary<int, ScenarioParagraph>
                            {
                                {
                                    1,
                                    new  ScenarioParagraph
                                    {
                                        Text = "This long winter, nearly everyone here lost a friend or a family member. First, to hunger. Then, to disease. Finally, the five remaining pillars of the community, the only heroes this land had ever known, suddenly left. Now, when you look into the distant eyes of the last remaining residents, you realize they want to forget"
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