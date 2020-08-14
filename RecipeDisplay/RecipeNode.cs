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
    public partial class RecipeNodeUC : UserControl
    {
        public RecipeNodeUC()
        {
            InitializeComponent();
        }

        public Recipee Recipe;
        public List<RecipeNodeUC> IncomingRecipes = new List<RecipeNodeUC>();
        public List<RecipeNodeUC> OutGoingRecipes = new List<RecipeNodeUC>();
        public int gridRow;
        public int gridColumn;
        public int gridRowOffsetToParent;
        public int gridColumnOffsetToParent;
        public int childrenWidth;

        public void Fill()
        {
            this.tableLayoutPanel1.RowCount = Math.Max(Recipe.Inputs.Count, Recipe.Outputs.Count);
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.AutoSize = true;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            for (int i = 0; i < this.tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
            this.BackColor = Color.Red;
            for (int i = 0; i < Recipe.Inputs.Count; i++)
            {
                var item = Recipe.Inputs[i];
                var l = new Label()
                {
                    Text = $"{item.Quantity}x {item.Name}",
                    AutoSize = true,
                    BackColor = Color.Green

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
                    BackColor = Color.Green


                };
                this.tableLayoutPanel1.Controls.Add(l, 1, i);
            }
        }
    }

    public class RecipeNode
    {
        public RecipeNode()
        {
        }

        public Recipee Recipe;
        public List<RecipeNode> IncomingRecipes = new List<RecipeNode>();
        public List<RecipeNode> OutGoingRecipes = new List<RecipeNode>();
        public int gridRowOffsetToParent;
        public int gridColumnOffsetToParent;
        public int childrenWidth;

        
    }
}
