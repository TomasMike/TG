using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TG.Forms
{
    public partial class AskerForm : Form
    {
        public AskerForm()
        {
            InitializeComponent();
        }

        public List<IAskerOption> PickAskerOptions = new List<IAskerOption>();
        public AskerForm(IEnumerable<IAskerOption> list,bool canCancel)
            : this()
        {
            foreach (var o in list)
            {
                var b = new AskerButton();
                b.Text = o.GetOptionDescription();
                b.AttachedOption = o;
                b.Click += pickOptionClick;
            }

            if(canCancel)

        }

        private void pickOptionClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



    }

    public class AskerButton : Button
    {
        public IAskerOption AttachedOption;
    }


}
