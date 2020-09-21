using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG.Combat;

namespace TG.CustomControls
{
    public partial class EncounterCardPnl : Panel
    {
        private Panel AttacksPnl;
        private Panel InitialSidePnl;

        public EncounterCardPnl()
        {
            //Location = new Point(10, 10);
            //Size = new Size(50, 50);
            AutoScroll = true;

            InitializeComponent();
        }

        public EncounterCardPnl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public EncounterCardPnl(EncounterCard card)
            :this()
        {
            var flow = new FlowLayoutPanel();
            this.Controls.Add(flow);
            flow.AutoSize = true;
            flow.Dock = DockStyle.Fill;
            flow.BackColor = Color.Beige;

            flow.Controls.Add(new Label { AutoSize = true,Text = card.Name });
            flow.Controls.Add(new Label { Text = $"dmg:{card.CurrentDamage }" }) ;
            


        }

       
    }
}
