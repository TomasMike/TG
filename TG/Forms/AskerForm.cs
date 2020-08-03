using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TG.PlayerDecisionIO;

namespace TG.Forms
{
    public partial class AskerForm<T> : Form
    {
        public AskerForm()
        {
            InitializeComponent();
        }

        public List<IAskerOption<T>> PickedAskerOptions = new List<IAskerOption<T>>();

        public AskerForm(string question, IEnumerable<IAskerOption<T>> list, bool canCancel)
            : this()
        {
            this.AutoSize = true;
            flowLayoutPanel1.Controls.Add(
                new Label()
                {
                    Text = question,
                    AutoSize = true
                }
            );

            foreach (var o in list)
            {
                var b = new AskerButton<T>();
                b.Text = o.GetOptionDescription();
                b.AttachedOption = o;
                b.Click += pickOptionClick;
                flowLayoutPanel1.Controls.Add(b);
            }

            if (canCancel)
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
            if (b == null)
                throw new Exception();

            PickedAskerOptions.Add(b.AttachedOption);
            this.Close();
        }
    }

    public class AskerButton<T> : Button
    {
        public IAskerOption<T> AttachedOption;
    }
}