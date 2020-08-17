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
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            tableLayoutPanel1 = new TableLayoutPanel();
            this.Controls.Add(tableLayoutPanel1);
        }

        public TableLayoutPanel tableLayoutPanel1;

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
            this.tableLayoutPanel1.RowCount = (Recipe.Inputs.Count + Recipe.Outputs.Count);
            this.tableLayoutPanel1.ColumnCount = 0;
      
            this.BackColor = Color.LightYellow;
            for (int i = 0; i < Recipe.Inputs.Count; i++)
            {
                var item = Recipe.Inputs[i];
                var l = new Label()
                {
                    Text = $"{item.Quantity}x {item.Name}",
                    AutoSize = true,
                    BackColor = Color.Orange
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
                    BackColor = Color.LightGreen


                };
                this.tableLayoutPanel1.Controls.Add(l, 0, Recipe.Inputs.Count + i);
            }

            var width = 0;
            foreach (Label item in this.tableLayoutPanel1.Controls)
            {
                var w = TextRenderer.MeasureText(item.Text, DefaultFont).Width;
                width = Math.Max(w, width);
            }
            tableLayoutPanel1.Width = width;
            tableLayoutPanel1.Height = tableLayoutPanel1.Controls.Count * TextRenderer.MeasureText("abc", DefaultFont).Height;
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
