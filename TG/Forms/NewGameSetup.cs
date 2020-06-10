using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG.Enums;

namespace TG.Forms
{
    public partial class NewGameSetup : Form
    {
        public NewGameSetup()
        {
            InitializeComponent();
        }

        public string[] CharacterDataSource = Enum.GetNames(typeof(CharacterName));
        public string[] ArchetypeDataSource = Enum.GetNames(typeof(CharacterArchetype));

        private void NewGameSetupcs_Load(object sender, EventArgs e)
        {
            p1name.Text = "Tomo";
            p1char.DataSource = CharacterDataSource;
            p1arch.DataSource = ArchetypeDataSource;
            foreach (Control c in p2panel.Controls)
            {
                c.Hide();
            }
        }

        private void ValidateNameBoxes(object sender, CancelEventArgs e)
        {
            TextBox control = sender as TextBox;
            control.Focus();
            e.Cancel = control.Text == string.Empty;
            if (e.Cancel)
            {
                errorProvider1.SetError(control,"no empty string maan");
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
            var save = new SaveSheet();
            save.Players.Add(new Player()
            {
                Character = NewGameDataLib
                    .GetStartingCharacter(
                        EnumUtils.ParseStringToEnum<CharacterName>(p1char.SelectedText),
                        EnumUtils.ParseStringToEnum<CharacterArchetype>(p1arch.SelectedText)
                        )
            });

        }
    }
}
