using System.Drawing;
using System.Windows.Forms;

namespace TG
{
    public static class Extensions
    {
        public static void Enable(this Button button)
        {
            button.Enabled = true;
            button.ForeColor = Color.Black;
        }

        public static void Disable(this Button button)
        {
            button.Enabled = false;
            button.ForeColor = Color.White;
        }
    }
}