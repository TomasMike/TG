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
    public partial class AskerForm : Form
    {
        public AskerForm()
        {
            InitializeComponent();
            this.AutoSize = true;
        }

        public T Ask<T>(IEnumerable<T> list)
        {

        }
    }

    public class Option<T>
    {
        public T option;
        public string TextDescription;
    }
}
