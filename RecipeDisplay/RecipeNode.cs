using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeDisplay
{
    public partial class RecipeNode : UserControl
    {
        public RecipeNode()
        {
            InitializeComponent();
        }

        public Recipe Recipe;
        public List<RecipeNode> IncomingRecipes = new List<RecipeNode>();
        public List<RecipeNode> OutGoingRecipes = new List<RecipeNode>();
        public int gridRow;
        public int gridColumn;
        public int childrenWidth;

        public void Fill()
        {
            this.tableLayoutPanel1.RowCount = Math.Max(Recipe.Inputs.Count, Recipe.Outputs.Count);
            this.tableLayoutPanel1.AutoSize = true;
            this.BackColor = Color.Red;
            for (int i = 0; i < Recipe.Inputs.Count; i++)
            {
                var item = Recipe.Inputs[i];
                var l = new Label()
                {
                    Text = $"{item.Quantity}x {item.Name}",
                    AutoSize = true,

                };
                this.tableLayoutPanel1.Controls.Add(l, 0, i);
            }
            for (int i = 0; i < Recipe.Outputs.Count; i++)
            {
                var item = Recipe.Outputs[i];
                var l = new Label()
                {
                    Text = $"{item.Quantity}x {item.Name}",
                    AutoSize = true,

                };
                this.tableLayoutPanel1.Controls.Add(l, 1, i);
            }
        }
    }
}
