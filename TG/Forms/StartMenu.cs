using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TG.Forms
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {
            var newGameBtn = new Button()
            {
                Text = "New Game",
            };
            newGameBtn.Click += NewGameStart;

            var loadGameBtn = new Button()
            {
                Text = "Load Game",
            };
            loadGameBtn.Click += LoadGameStart;

            flowLayoutPanel1.Controls.Add(newGameBtn);
            flowLayoutPanel1.Controls.Add(loadGameBtn);
        }

        private void NewGameStart(object sender, EventArgs e)
        {
            new NewGameSetup().ShowDialog();
            //this.Close();
        }

        private void LoadGameStart(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var x = new OpenFileDialog(){InitialDirectory = @"C:\Users\tmi\Source\Repos\TG\SaveFiles" };
            var c  =x.ShowDialog();

        }
    }
}
