using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += Form1_Paint;
            this.AutoSize = true;
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\XMLFile1.xml")));

            var recipes = new List<Recipe>();

            foreach (XmlNode node in doc.SelectNodes("//recipe"))
            {
                var r = new Recipe();
                r.Name = node.Attributes["name"]?.Value;
                foreach (XmlNode child in node.ChildNodes)
                {
                    var m = new RecipePart()
                    {
                        Name = child.Attributes["name"].Value,
                        Quantity = float.Parse(child.Attributes["q"].Value)
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

            var x = TreeCharter.FindPaths(labels, "Zinc Ore", "Zinc Plate");

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
        public List<RecipePart> Inputs = new List<RecipePart>();
        public List<RecipePart> Outputs = new List<RecipePart>();
        public string Name;
        private string getDebugText => $"{string.Join(",", Inputs)}=>{string.Join(",", Outputs)}" ;
    }

    public class RecipePart
    {
        public string Name;
        public float Quantity;

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
                    if(!nodes.Contains(item))
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

    public static class TreeCharter
    {
        public static void ChartTree(IEnumerable<RecipeNode> nodes ,TableLayoutPanel tlp)
        {
            var roots = nodes.Where(_ => _.IncomingRecipes.Count == 0).OrderByDescending(_ => Helper.GetTreeSize(_));

            //m(tlp, roots,);
        }

        private static void m(TableLayoutPanel tlp, IEnumerable<RecipeNode> roots, int parentRow,int parentColumn)
        {
            foreach (var item in roots)
            {

            }
            //foreach (var item in roots)
            //{
            //    if (tlp.Controls.Contains(item))
            //        continue;
            //    var position = (int)Math.Ceiling(item.OutGoingRecipes.Count / 2.0f);
            //    var controlsFromSameRow = tlp.GetControlsFromRow(row);
            //    if (controlsFromSameRow.Any())
            //    {
            //        var mostRightInColumnColIndex = controlsFromSameRow.Max(_ => tlp.GetColumn(_));
            //        var mostRightInColumn = tlp.GetControlFromPosition(mostRightInColumnColIndex, 0) as RecipeNode;
            //        /*1*/
            //        position += mostRightInColumnColIndex + (int)Math.Floor(mostRightInColumn.OutGoingRecipes.Count / 2.0f);
            //    }
            //    item.Fill();
            //    //tlp.Controls.Add(new Label() { Text=$"{position - 1}"}, position - 1, 0);
            //    tlp.Controls.Add(item, position - 1, row);

            //    m(tlp, item.OutGoingRecipes, row + 1);
            //}
        }

        public static IEnumerable<Control> GetControlsFromRow(this TableLayoutPanel panel, int row)
        {
            var retVal = new List<Control>();

            foreach (Control item in panel.Controls)
            {
                if (panel.GetRow(item) == row)
                {
                    retVal.Add(item);
                }

            }
            return retVal;
        }

        public static IEnumerable<Control> GetControlsFromColumn(this TableLayoutPanel panel, int column)
        {
            var retVal = new List<Control>();

            foreach (Control item in panel.Controls)
            {
                if (panel.GetColumn(item) == column)
                {
                    retVal.Add(item);
                }

            }
            return retVal;
        }

        public static List<Stack<RecipeNode>> FindPaths(IEnumerable<RecipeNode> nodes, string recipeFrom, string recipeTo)
        {
            var foundPaths = new List<Stack<RecipeNode>>();
            Action<RecipeNode, Stack<RecipeNode>> q = null;

            var startNodes = nodes.Where(_ => _.Recipe.Inputs.Any(__ => __.Name == recipeFrom));
            var endNodes = nodes.Where(_ => _.Recipe.Outputs.Any(__ => __.Name == recipeTo));

           

            q = (node,path) => 
            {
                foreach (var item in node.OutGoingRecipes)
                {
                    if (path.Contains(item))
                        continue;

                    path.Push(item);
                    if(endNodes.Contains(item))
                    {
                        foundPaths.Add(new Stack<RecipeNode>(path));
                    }
                    else
                        q(item, path);
                    path.Pop();

                }
            };

            foreach (var item in startNodes)
            {
                var p = new Stack<RecipeNode>();
                p.Push(item);
                q(item, p);
            }

            return foundPaths;
        }


    }


}
