using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RecipeDisplay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private enum Types
        {
            Chrome,
            Zinc
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += Form1_Paint;
            this.AutoSize = true;
            List<RecipeNode> labels = InitRecipes("Chrome");

            var choosenResource = Types.Chrome;
            Stack<RecipeNode> x;
            switch (choosenResource)
            {
                case Types.Chrome: 
                    x = FindOptimalProductionPath("Chrome","Chromium Ore","Chromium Ingot",1000);
                    break;
                case Types.Zinc:
                    x = FindOptimalProductionPath("Zinc", "Zinc Ore", "Zinc Ingot", 1000);
                    break;
                default:
                    break;
            }

            if (false)
            {

                var roots = labels.Where(_ => _.IncomingRecipes.Count == 0);

                Action<IEnumerable<RecipeNode>> d = null;

                d = n =>
                {

                    if (n.Count() == 0)
                        return;

                    var controlsAdded = new List<RecipeNode>();
                    foreach (var item in n)
                    {
                        item.AutoSize = true;
                        item.Fill();

                        if (item.Recipe.Name == "ble")
                        {
                            item.BackColor = Color.Green;
                        }
                        if (!flowLayoutPanel1.Controls.Contains(item))
                        {
                            flowLayoutPanel1.Controls.Add(item);
                            controlsAdded.Add(item);
                        }
                    }

                    if (flowLayoutPanel1.Controls.Count > 0)
                        flowLayoutPanel1.SetFlowBreak(flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1], true);


                    foreach (var item in controlsAdded)
                    {
                        d(item.OutGoingRecipes);
                    }
                };

                d(roots);

            }
            else
            {
                flowLayoutPanel1.Hide();

                var t = new TableLayoutPanel();
                t.RowCount = 10;
                t.ColumnCount = 10;
                for (int i = 0; i < 10; i++)
                {
                    //t.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                    //t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                    t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                }

                t.Dock = DockStyle.Fill;
                t.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;


                t.BackColor = Color.Beige;
                TreeCharter.ChartTree(labels, t);
                this.Controls.Add(t);
                this.Refresh();

            }

            this.flowLayoutPanel1.Paint += Form1_Paint;


        }

        private static Stack<RecipeNode> FindOptimalProductionPath(string fileName, string startingResourceName, string endingResourceName, int startingInputQuantity)
        {
            List<RecipeNode> labels = InitRecipes(fileName);
            TreeCharter.FindPathsv2(labels, startingResourceName, endingResourceName);
            var x = TreeCharter.FindPathsv1(labels, startingResourceName, endingResourceName);
            var pathsYield = new List<Tuple<decimal, Stack<RecipeNode>>>();
            foreach (var item in x)
            {
                var q = TreeCharter.GetQuantityv2(item.ToList(), labels.ToList(), new ResourceChunk() { Name = startingResourceName, Quantity = startingInputQuantity }, endingResourceName);
                pathsYield.Add(new Tuple<decimal, Stack<RecipeNode>>(q, item));
            }
            var best = pathsYield.OrderByDescending(_ => _.Item1).ToList().First();
            return best.Item2;
        }

        private static List<RecipeNode> InitRecipes(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetFullPath(Path.Combine(Application.StartupPath, $@"..\..\{fileName}.xml")));

            var recipes = new List<Recipe>();

            foreach (XmlNode node in doc.SelectNodes("//recipe"))
            {
                var r = new Recipe();
                r.Name = node.Attributes["name"]?.Value;
                foreach (XmlNode child in node.ChildNodes)
                {
                    var m = new ResourceChunk()
                    {
                        Name = child.Attributes["name"].Value,
                        Quantity = decimal.Parse(child.Attributes["q"].Value.Replace(".",CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                    };

                    if (child.Name == "input")
                        r.Inputs.Add(m);
                    else
                        r.Outputs.Add(m);
                }

                recipes.Add(r);
            }



            List<RecipeNode> labels = new List<RecipeNode>();

            foreach (Recipe rec in recipes)
            {
                var r = new RecipeNode()
                {
                    Recipe = rec
                };
                labels.Add(r);
            }



            foreach (var item in labels)
            {
                foreach (var input in item.Recipe.Inputs)
                {
                    foreach (var matchedRecipeLabel in labels.Where(_ => _.Recipe.Outputs.Any(__ => __.Name == input.Name)))
                    {
                        item.IncomingRecipes.Add(matchedRecipeLabel);
                    }
                }

                foreach (var output in item.Recipe.Outputs)
                {
                    foreach (var matchedRecipeLabel in labels.Where(_ => _.Recipe.Inputs.Any(__ => __.Name == output.Name)))
                    {
                        item.OutGoingRecipes.Add(matchedRecipeLabel);
                    }
                }
            }

            return labels;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            pen.Width = 4;
            foreach (RecipeNode me in this.flowLayoutPanel1.Controls)
            {
                foreach (RecipeNode him in me.IncomingRecipes)
                {
                    Point pMe = new Point(me.Location.X + me.Size.Width / 2, me.Location.Y + me.Size.Height / 2);
                    Point pHim = new Point(him.Location.X + him.Size.Width / 2, him.Location.Y + him.Size.Height / 2);
                    g.DrawLine(pen, pMe.X, pMe.Y, pHim.X, pHim.Y);
                }

            }
        }
    }



    [DebuggerDisplay("{getDebugText}")]
    public class Recipe
    {
        public List<ResourceChunk> Inputs = new List<ResourceChunk>();
        public List<ResourceChunk> Outputs = new List<ResourceChunk>();
        public string Name;
        private string getDebugText => $"{string.Join(",", Inputs)}=>{string.Join(",", Outputs)}";
    }

    public class ResourceChunk
    {
        public string Name;
        public decimal Quantity;

        public override string ToString()
        {
            return $"{Quantity}x {Name}";
        }
    }

    public static class Helper
    {
        public static int GetTreeSize(RecipeNode node)
        {
            var nodes = new List<RecipeNode>();

            Action<RecipeNode> a = null;
            a = n =>
            {
                foreach (var item in n.IncomingRecipes)
                {
                    if (!nodes.Contains(item))
                    {
                        nodes.Add(item);
                        a(item);
                    }
                }

                foreach (var item in n.OutGoingRecipes)
                {
                    if (!nodes.Contains(item))
                    {
                        nodes.Add(item);
                        a(item);
                    }
                }
            };

            a(node);
            return nodes.Count;
        }
    }


}
