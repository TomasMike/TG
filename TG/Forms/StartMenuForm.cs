using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TG.Forms
{
    public partial class StartMenuForm : Form
    {

        public StartMenuForm()
        {
            InitializeComponent();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {
            var quickStartLoadBtn = new Button()
            {
                Text = "Load Newest Save",
                Width = 100
            };
            quickStartLoadBtn.Click += LoadNewestSave;

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

            flowLayoutPanel1.Controls.Add(quickStartLoadBtn);
            flowLayoutPanel1.Controls.Add(newGameBtn);
            flowLayoutPanel1.Controls.Add(loadGameBtn);
        }

        private void NewGameStart(object sender, EventArgs e)
        {
            var ng = new NewGameSetupForm();
            ng.ShowDialog();

            this.Close();
        }

        private void LoadGameStart(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = SaveManager.SaveFolder;
            ofd.ShowDialog();
            SaveManager.Load(ofd.FileName);
            this.Close();

        }

        private void LoadNewestSave(object sender, EventArgs e)
        {
            FileInfo latestFileInfo = null;

            foreach (var f in Directory.GetFiles(SaveManager.SaveFolder,"*.xml"))
            {
                var i = new FileInfo(f);
                if (latestFileInfo == null || latestFileInfo.LastWriteTime < i.LastWriteTime)
                    latestFileInfo = i;
            }

            if (latestFileInfo == null)
            {
                MessageBox.Show("No save file in save folder.");
                return;
                
            }
            SaveManager.Load(latestFileInfo.FullName);

            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
