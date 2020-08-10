using System.Drawing;
using System.Windows.Forms;

namespace TG
{
    public static class Extensions
    {
        public static void Enable(this Button button)
        {
            button.Enabled = true;
            button.BackColor = Color.White;
        }

        public static void Disable(this Button button)
        {
            button.Enabled = false;
            button.BackColor = Color.Black;
        }
    }
}