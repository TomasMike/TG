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
    public partial class ComDipCardPnl : Panel
    {
        public ComDipCardPnl()
        {
            Location = new Point(10, 10);
            Size = new Size(50, 50);
            AutoScroll = true;

            InitializeComponent();
        }

        public ComDipCardPnl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ComDipCardPnl(Card card)
        {

        }

       
    }
}
