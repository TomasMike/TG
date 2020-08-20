using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TG.Enums;
using TG.HelpersUtils;
using TG.Libs;
using TG.PlayerCharacterItems;
using TG.SavingLoading;

namespace TG.Forms
{
    public partial class NewGameSetupForm : Form
    {
        public NewGameSetupForm()
        {
            InitializeComponent();
        }

        public string[] CharacterDataSource => Enum.GetNames(typeof(CharacterName));
        public string[] ArchetypeDataSource => Enum.GetNames(typeof(CharacterArchetype));

        private void NewGameSetupcs_Load(object sender, EventArgs e)
        {
            //nejake default hodnoty pre test
            p1name.Text = "Tomo";
            saveFilenameTextBox.Text = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            //p1char.DataSource = p2char.DataSource = p3char.DataSource = p4char.DataSource = CharacterDataSource;
            //p1arch.DataSource = p2arch.DataSource = p3arch.DataSource = p4arch.DataSource = ArchetypeDataSource;

            p1char.DataSource = CharacterDataSource;
            p2char.DataSource = CharacterDataSource;
            p3char.DataSource = CharacterDataSource;
            p4char.DataSource = CharacterDataSource;
            p1arch.DataSource = ArchetypeDataSource;
            p2arch.DataSource = ArchetypeDataSource;
            p3arch.DataSource = ArchetypeDataSource;
            p4arch.DataSource = ArchetypeDataSource;
            foreach (Control c in p2panel.Controls) { c.Hide(); }
            foreach (Control c in p3panel.Controls) { c.Hide(); }
            foreach (Control c in p4panel.Controls) { c.Hide(); }
        }

        private void ValidateNameBoxes(object sender, CancelEventArgs e)
        {
            TextBox control = sender as TextBox;
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

            #region

            Action<ComboBox, ComboBox, PlayerNumber, TextBox> initPlayer = (charCmb, archCmb, pNum, nameTxb) =>
              {
                  if (charCmb.Visible && !string.IsNullOrEmpty(nameTxb.Text))
                  {
                      saveSheet.Players.Add(new Player()
                      {
                          Character = NewGameDataLib
                         .GetStartingCharacter(
                             EnumUtils.ParseStringToEnum<CharacterName>(charCmb.SelectedItem.ToString()),
                             EnumUtils.ParseStringToEnum<CharacterArchetype>(archCmb.SelectedItem.ToString())
                             ),
                          Name = nameTxb.Text,
                          PlayerNumber = pNum,
                          CurrentLocation = 101
                      });
                  }
              };

            initPlayer(p1char, p1arch, PlayerNumber.Player1, p1name);
            initPlayer(p2char, p2arch, PlayerNumber.Player2, p2name);
            initPlayer(p3char, p3arch, PlayerNumber.Player3, p3name);
            initPlayer(p4char, p4arch, PlayerNumber.Player4, p4name);

            #endregion

            saveSheet.Locations.Add(new LocationSaveObject { LocationNumber = 101, MenhirValue = 9 - saveSheet.Players.Count });

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
                case '2': p = p2panel; break;
                case '3': p = p3panel; break;
                case '4': p = p4panel; break;
                default: throw new Exception();
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