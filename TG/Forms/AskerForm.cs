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
    public partial class AskerForm<T> : Form
    {
        public AskerForm()
        {
            //InitializeComponent();
        }

        public List<IAskerOption<T>> PickAskerOptions = new List<IAskerOption<T>>();
        public AskerForm(string question, IEnumerable<IAskerOption<T>> list,bool canCancel)
            : this()
        {
            flowLayoutPanel1.Controls.Add(new Label() { Text = question});

            foreach (var o in list)
            {
                var b = new AskerButton<T>();
                b.Text = o.GetOptionDescription();
                b.AttachedOption = o;
                b.Click += pickOptionClick;
                flowLayoutPanel1.Controls.Add(b);
            }

            if(canCancel)
            {
                var b = new Button();
                b.Text = "Cancel";
                b.Click += (sender, args) => this.Close();
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void pickOptionClick(object sender, EventArgs e)
        {
            var b = sender as AskerButton<T>;
            if(b == null)
                throw new Exception();
        }
    }

    public class AskerButton<T> : Button
    {
        public IAskerOption<T> AttachedOption;
    }


}
