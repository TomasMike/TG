using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TG.CoreStuff;
using TG.Exploration;
using TG.Libs;
using TG.PlayerDecisionIO;

namespace TG.Managers
{
    public static class ExplorationManager
    {
        public static void StartExploration(int location)
        {
            var activeExploration = ExplorationScenariosLib.ExplorationScenarios[location];

            StartExploration(activeExploration);
        }

        public static void StartExploration(ExplorationScenario scenario)
        {
            Action<ScenarioParagraph> loop = null;
            loop = (par) =>
            {
                ParagraphOption pickedParagraphOption;

                if (par.ForcedOptions?.Any(_ => _.Check(null)) ?? false)
                {
                    MessageBox.Show(par.Text + (string.IsNullOrEmpty(par.AdditionalText) ? "" : "\r\n" + par.AdditionalText));

                    var fo = par.ForcedOptions.First(_ => _.Check(null));
                    if (fo is ForceScenarioParagraphForcedOption)
                    {
                        pickedParagraphOption = par.ParagraphOptions
                           .First(_ => _.ParagraphNumToRedirectToAfter == ((ForceScenarioParagraphForcedOption)fo).RedirectToParagraphNum);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    //par.PreParagraphChoiceEffect?.
                    
                    //if ()
                    pickedParagraphOption = Asker.Ask(par.Text, par.ParagraphOptions
                        .Where(po => po.OptionCondition == null ? true : po.OptionCondition(GetEventArgs)));
                }

                var nextParagraph = pickedParagraphOption.ParagraphNumToRedirectToAfter;

                if (nextParagraph == -1)
                {
                    //end
                }
                else
                {
                    loop(nextParagraph == 0 ? scenario.IntroParagraph : scenario.Options.First(_ => _.VerseNumber == nextParagraph));
                }
            };

            loop(scenario.IntroParagraph);

        }

        private static ExplorationEventArgs GetEventArgs = new ExplorationEventArgs
        {
            ActiveParty = Game.Instance.ActiveParty,
            LocationOfExploration = Game.Instance.ActivePlayer.CurrentLocationCard
        };
    }
}