using System.Linq;
using TG.Exploration;
using TG.Forms;
using TG.Libs;
using TG.PlayerDecisionIO;

namespace TG.Managers
{

    public static class CombatManager
    {
        public static void Start()
        {
            var encounterCard = EncounterLib.Encounters.First();

            CombatForm cf = new CombatForm(encounterCard);
            cf.ShowDialog();
        }
    }
}