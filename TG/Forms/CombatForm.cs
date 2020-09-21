using System.Windows.Forms;
using TG.CustomControls;

namespace TG.Forms
{
    public partial class CombatForm : Form
    {
        public CombatForm()
        {
            InitializeComponent();
        }
        public CombatForm(EncounterCard e)
            :base()
        {


            var x = new EncounterCardPnl(e);
            this.Controls.Add(x);
        }
    }
}
