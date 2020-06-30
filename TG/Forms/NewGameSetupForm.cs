using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG.Enums;

namespace TG.Forms
{
    public partial class NewGameSetupForm : Form
    {

        public NewGameSetupForm()
        {
            InitializeComponent();
        }

        public string[] CharacterDataSource = Enum.GetNames(typeof(CharacterName));
        public string[] ArchetypeDataSource = Enum.GetNames(typeof(CharacterArchetype));

        private void NewGameSetupcs_Load(object sender, EventArgs e)
        {
            //nejake default hodnoty pre test
            p1name.Text = "Tomo";
            saveFilenameTextBox.Text = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            p1char.DataSource = p2char.DataSource = p3char.DataSource = p4char.DataSource = CharacterDataSource;
            p1arch.DataSource = p2arch.DataSource = p3arch.DataSource = p4arch.DataSource = ArchetypeDataSource;
            foreach (Control c in p2panel.Controls) { c.Hide(); }
            foreach (Control c in p3panel.Controls) { c.Hide(); }
            foreach (Control c in p4panel.Controls) { c.Hide(); }
        }

        private void ValidateNameBoxes(object sender, CancelEventArgs e)
        {
            TextBox control = sender as TextBox;
            control.Focus();
            e.Cancel = control.Text == string.Empty;
            if (e.Cancel)
            {
                errorProvider1.SetError(control, "no empty string maan");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var charType = typeof(CharacterName);
            var archType = typeof(CharacterArchetype);

            if (saveFilenameTextBox.Text.Any(_ => Path.GetInvalidFileNameChars().Contains(_)))
            {
                MessageBox.Show("savefilename contains invalid characters");
                return;
            }

            var saveSheet = new SaveSheet { fileName = saveFilenameTextBox.Text };

            //TODO init ostatnych hracov a ostatne veci do savu
            saveSheet.Players.Add(new Player()
            {
                Character = NewGameDataLib
                    .GetStartingCharacter(
                        EnumUtils.ParseStringToEnum<CharacterName>(p1char.SelectedItem.ToString()),
                        EnumUtils.ParseStringToEnum<CharacterArchetype>(p1arch.SelectedItem.ToString())
                        ),
                Name = p1name.Text,
                PlayerNumber = 1
            });

            saveSheet.Locations.Add( new LocationSaveObject { LocationNumber = 101,MenhirValue = 9 - saveSheet.Players.Count });

            if (SaveManager.CurrentSaveSheet != null)
            {
                throw new Exception("current save sheet isnt empty, wft?");
            }

            SaveManager.CurrentSaveSheet = saveSheet;
            SaveManager.Save();
            this.Close();


        }

        private void AddRemovePlayer(object sender, EventArgs e)
        {
            Panel p;
            switch ((sender as Button).Text.Last())
            {
                case '2': p = p2panel;break;
                case '3': p = p3panel;break;
                case '4': p = p4panel;break;
                default:throw new Exception();
            }

            foreach (Control c in p.Controls)
            {
                if (c.Visible)
                    c.Hide();
                else
                    c.Show();
            }
        }
    }
}
