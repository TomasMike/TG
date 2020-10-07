using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TG.CoreStuff;
using TG.Enums;
using TG.Exploration;
using TG.HelpersUtils;
using TG.PlayerCharacterItems;
using TG.PlayerDecisionIO;
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
                                CheckForcedOption = _ =>
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
                                        MainText = "Visit the families of the champions from the first expedition",
                                        OtherText = "If you're to find them, knowing more about them might help.",
                                        ParagraphAction = new ParagraphAction
                                        {
                                            ParagraphNumToRedirectToAfter = 1
                                        }
                                    },
                                    new ParagraphOption
                                    {
                                        MainText = "Ask the townsfolk to help you prepare",
                                        ParagraphAction = new ParagraphAction
                                        {
                                            ParagraphNumToRedirectToAfter = 3
                                        }
                                    },
                                    new ParagraphOption
                                    {
                                        MainText = "Rest for the day in your own home",
                                         ParagraphAction = new ParagraphAction
                                        {
                                            ParagraphNumToRedirectToAfter = 5
                                        }
                                    },
                                    new ParagraphOption
                                    {
                                        MainText = "Wander the alleys twisted by the wyrdness",
                                        ParagraphAction = new ConditionalParagrapthAction
                                        {
                                            ParagraphNumToRedirectToAfter = 9,
                                            Condition = e =>  e.LocationOfExploration.MenhirValue == -1
                                        },
                                    },
                                    new ExplorationEndsParagraphOption()
                                }
                            },
                            Options = new List<ScenarioParagraph>
                            {
                                new ScenarioParagraph
                                {
                                    VerseNumber = 1,
                                    Text = "This long winter, nearly everyone here lost a friend or a family member. First, to hunger. Then, to disease. Finally, the five remaining pillars of the community, the only heroes this land had ever known, suddenly left. Now, when you look into the distant eyes of the last remaining residents, you realize they want to forget",
                                    ParagraphOptions = new List<ParagraphOption>
                                    {
                                        new ParagraphOption
                                        {
                                            MainText = "Loosen their tongues with mead",
                                            OtherText = "There is an old custom: a late-night wake for those who wandered far from their home. Holding it for everyone who left with the expedition won't be cheap, though.",
                                            ActionEffectDescription = "Pay 1 Wealth or 1 Food to go to Verse 2",
                                            ParagraphAction = new PayResourcesParagrapthAction
                                            {
                                                PaymentOptions = new IEnumerable<Tuple<CharacterResourceType, int>>[]
                                                {
                                                    new List<Tuple<CharacterResourceType, int>>
                                                    {
                                                        new Tuple<CharacterResourceType, int>(CharacterResourceType.Wealth,1),
                                                        new Tuple<CharacterResourceType, int>(CharacterResourceType.Food,1),
                                                    },
                                                },
                                                ParagraphNumToRedirectToAfter = 2
                                            },
                                        },
                                        new ParagraphOption
                                        {
                                            MainText = "Ask them to share their burdens.",
                                            ParagraphAction = new ConditionalParagrapthAction
                                            {
                                                Condition = _ => Game.Instance.ActiveParty.Any(p => p.Character.Empathy >= 1),
                                                ParagraphNumToRedirectToAfter = 2,
                                            }
                                        },
                                        new BackToIntroParagraphOption()
                                    }
                                },
                                new ScenarioParagraph
                                {
                                    VerseNumber = 2,
                                    Text = "It takes a while to break the silence of the grief-stricken people, but when you do, stories of separations and departures flood you like torrential rain. You try to remember every detail. The color of a palfrey horse the village priestess, Neante, rode. The ornament on the hauberk that young Lord Yvain wore. The strange drinking horn Erfyr, the smith, used to lug around. The birthmark of Fael, the master huntsman. The embroidered cape of Aubert, the seasoned traveler who'd seen all parts of the island. Who knows what detail can help you down the road?",
                                    ParagraphOptions = new List<ParagraphOption>
                                    {
                                        new ParagraphOption
                                        {
                                            MainText = "Gain 1 of the \"Fate of the Expedition\" ",
                                            ParagraphAction = new EffectParagraphAction
                                            {
                                                ParagraphNumToRedirectToAfter = -1,
                                                Action = _ => SaveManager.CurrentSaveSheet.GainStatus("Fate of the Expedition", 1)
                                            }
                                        }
                                    }
                                },
                                new ScenarioParagraph
                                {
                                    VerseNumber = 3,
                                    Text = "Though they have little left, they share with you their last remaining supplies. Somehow, this seems unworthy of a hero, but since all the true heroes where lost, who will dare to question your methods?",
                                    ParagraphOptions = new List<ParagraphOption>
                                    {
                                        new ParagraphOption
                                        {
                                            ParagraphAction = new EffectParagraphAction
                                            {
                                                Action = e =>
                                                {
                                                    if(
                                                        e.ActiveParty.Any(p => p.Character.Reputation >= 1) &&
                                                        !SaveManager.CurrentSaveSheet.CheckStatus("Scrounger")
                                                        )
                                                    {
                                                        e.ActiveParty.ForEach(p => p.Character.EditCharProperty(CharacterAttribute.Food,EditCharPropertyChangeType.Add,2));
                                                    }

                                                    //TODO gain 1 random item
                                                    SaveManager.CurrentSaveSheet.GainStatus("Scrounger");
                                                },
                                                ParagraphNumToRedirectToAfter = -1
                                            }
                                        }
                                    }
                                },
                                new ScenarioParagraph
                                {
                                    VerseNumber = 4,
                                    Text = "Some people in Cuanacht do not take that well.",
                                    ParagraphOptions = new List<ParagraphOption>
                                    {
                                        new ParagraphOption
                                        {
                                            ParagraphAction = new EffectParagraphAction
                                            {
                                                Action = e =>
                                                {
                                                    MessageBox.Show("Roll a die and add +2 for each point of your [Aggression]. Check the total result:");
                                                    
                                                    var dieRoll = new Random().Next(1,7);
                                                    var activePlayerAgg = Game.Instance.ActivePlayer.Character.Aggression;
                                                    var result = dieRoll + (activePlayerAgg*2);
                                                    
                                                    MessageBox.Show($"You rolled : {dieRoll}. Adding {activePlayerAgg*2} for your Aggression. Final result is:[{result}]");

                                                    if(1 <= result && result <= 3)
                                                    {
                                                        MessageBox.Show("Sticks and stones hurt, but the fact your own kin turned against you causes even more pain. Each Party member loses 1 [Health], 1 [Energy] and 1 [Rep]. Each Party member gains 1 [Terror]");
                                                        e.ActiveParty.ForEach(p =>
                                                        {
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentHealth,EditCharPropertyChangeType.Subtract,1);
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentEnergy,EditCharPropertyChangeType.Subtract,1);
                                                            p.Character.EditCharProperty(CharacterAttribute.Reputation,EditCharPropertyChangeType.Subtract,1);
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentTerror,EditCharPropertyChangeType.Add,1);
                                                        });
                                                    }
                                                    else if(4 <= result && result <= 5)
                                                    {
                                                        MessageBox.Show("You manage to break out and escape. Each Party member loses 1 [Energy] and 1 [Rep].");
                                                        e.ActiveParty.ForEach(p =>
                                                        {
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentEnergy,EditCharPropertyChangeType.Subtract,1);
                                                            p.Character.EditCharProperty(CharacterAttribute.Reputation,EditCharPropertyChangeType.Subtract,1);
                                                        });
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("You teach them a good lesson. Perhaps too good - you don't stop hitting until one of them lies dead in a puddle of blood. Each Party member gains 2 [Terror].");
                                                        e.ActiveParty.ForEach(p => p.Character.EditCharProperty(CharacterAttribute.CurrentTerror,EditCharPropertyChangeType.Add,2));
                                                    }
                                                },
                                                ParagraphNumToRedirectToAfter = -1
                                            },
                                        }
                                    }
                                },
                                new ScenarioParagraph
                                {
                                    VerseNumber = 5,
                                    Text = "Many would refuse to call this place a 'home', but the familiar setting brings you some much needed serenity. As you lay to rest in your bed, you can't help but wonder whether it is the last night you will ever spend under this roof.",
                                    ParagraphOptions = new List<ParagraphOption>
                                    {
                                        new ParagraphOption
                                        {
                                            ParagraphAction = new EffectParagraphAction
                                            {
                                                Action = e =>
                                                {
                                                    if(e.LocationOfExploration.MenhirValue >= 0)
                                                    {
                                                        MessageBox.Show("You rest. Each Party member gains 2 [Health] and loose 2 [Terror]. You pass for the rest of the day.");
                                                        e.ActiveParty.ForEach(p =>
                                                        {
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentHealth,EditCharPropertyChangeType.Add,2);
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentHealth,EditCharPropertyChangeType.Add,2);
                                                        });
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("You rest. Each Party member gains 1 [Health] and loose 1 [Terror]. You pass for the rest of the day.");
                                                        e.ActiveParty.ForEach(p =>
                                                        {
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentHealth,EditCharPropertyChangeType.Add,1);
                                                            p.Character.EditCharProperty(CharacterAttribute.CurrentHealth,EditCharPropertyChangeType.Add,1);
                                                        });
                                                    }

                                                    e.ActiveParty.ForEach(p => Game.Instance.PlayerPassed(p));
                                                }
                                            }
                                        }
                                    }
                                },
                                new ScenarioParagraph
                                {
                                    VerseNumber = 6,
                                    Text = "Three women mourn in front of the long hall. One of them has lost her child, a girl of eight recently butchered like an animal in the hills outside Cuanacht. You feel your legs giving way. The faint memories of the night hunt now burn your mind like hot iron. You stumble away, trying not to look at the mourners' faces.",
                                    

                                }
                            }
                        }
                    },
                });
            private set => _explorationScenarios = value;
        }


    }
}