using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TG.Forms
{
    public partial class QuestionForm : Form
    {
        public QuestionType Mode;
        public string stringOutput;
        public int intOutput;

        public QuestionForm()
        {
            InitializeComponent();
        }

        public QuestionForm(string question)
            : this()
        {
            this.comboBox1.Hide();
            this.label1.Text = question;
        }

        public QuestionForm(string question, IEnumerable<QuestionFromComboBoxItem> items)
            : this()
        {
            this.textBox1.Hide();
            this.Mode = QuestionType.Dropdown;
            this.label1.Text = question;
            var cb = new ComboBox();
            cb.DisplayMember = "Name";
            cb.ValueMember = "Id";
            cb.Items.AddRange(items.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Mode == QuestionType.Dropdown)
                stringOutput = this.comboBox1.SelectedItem.ToString();
            else if (this.Mode == QuestionType.Text)
                stringOutput = this.textBox1.Text;
            else if (this.Mode == QuestionType.Int)
            {
                int i;
                if (int.TryParse(this.textBox1.Text, out i))
                {
                    intOutput = i;
                }
                else
                {
                    MessageBox.Show("napis cislo");
                    return;
                }
            }
            this.Close();
        }
    }

    public class QuestionFromComboBoxItem
    {
        public string _Name;
        public string _Id;

        public QuestionFromComboBoxItem(string name, string id)
        {
            _Name = name;
            _Id = id;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }

    public enum QuestionType
    {
        Text,
        Dropdown,
        Int
    }
}