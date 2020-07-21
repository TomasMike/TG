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
            ////tableLayoutPanel1.Visible = false;
            //TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();
            //dynamicTableLayoutPanel.Location = new System.Drawing.Point(26, 12);
            //dynamicTableLayoutPanel.Name = "TableLayoutPanel1";
            //dynamicTableLayoutPanel.Size = new System.Drawing.Size(228, 200);
            //dynamicTableLayoutPanel.BackColor = Color.LightBlue;
            //// Add rows and columns  
            //dynamicTableLayoutPanel.ColumnCount = 3;
            //dynamicTableLayoutPanel.RowCount = 5;
            //dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            //dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            //dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            //dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 52));
            //dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44 ));
            //dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44 ));
            //dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38 ));
            //dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 8 ));
            //TextBox textBox1 = new TextBox();
            //textBox1.Location = new Point(10, 10);
            //textBox1.Text = "I am a TextBox5";
            //textBox1.Size = new Size(200, 30);
            //CheckBox checkBox1 = new CheckBox();
            //checkBox1.Location = new Point(10, 50);
            //checkBox1.Text = "Check Me";
            //checkBox1.Size = new Size(200, 30);
            //// Add child controls to TableLayoutPanel and specify rows and column  
            //dynamicTableLayoutPanel.Controls.Add(textBox1, 0, 0);
            //dynamicTableLayoutPanel.Controls.Add(checkBox1, 0, 1);
            //Controls.Add(dynamicTableLayoutPanel);
            //return;
            this.AutoSize = true;
            //this.flowLayoutPanel1.AutoSize = true;
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

            var labelsOrdered = labels.OrderByDescending(_ => _.IncomingRecipes.Count);

            if (true)
            {
                //flowLayoutPanel1.Hide();

                var roots = labels.Where(_ => _.IncomingRecipes.Count == 0);

                
                
                
                Action<IEnumerable<RecipeNode>> d = null;


                //d = n =>
                //{

                //    if (n.Count() == 0)
                //        return;

                //    var controlsAdded = new List<RecipeNode>();
                //    foreach (var item in n)
                //    {
                //        item.AutoSize = true;
                //        item.Fill();

                //        if(item.Recipe.Name == "ble")
                //        {
                //            item.BackColor = Color.Green;
                //        }
                //        if (!flowLayoutPanel1.Controls.Contains(item))
                //        {
                //            flowLayoutPanel1.Controls.Add(item);
                //            controlsAdded.Add(item);
                //        }
                //    }
                    
                //    if(flowLayoutPanel1.Controls.Count > 0)
                //        flowLayoutPanel1.SetFlowBreak(flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count-1], true);


                //    foreach (var item in controlsAdded)
                //    {
                //            d(item.OutGoingRecipes);
                //    }
                //};

                //d(roots);
                //flowLayoutPanel1.Hide();

                var t = new TableLayoutPanel();
                for (int i = 0; i < 10; i++)
                {
                    t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                }
            
                t.Dock = DockStyle.Fill;
                t.Location = new Point(0, 0);
                t.Size = new Size(100, 100);
                t.BackColor = Color.Beige;
                TreeCharter.ChartTree(labels, t);
                this.Controls.Add(t);
                this.Refresh();
            }
            else
            {
                foreach (var item in labels)
                {
                    item.AutoSize = true;
                    item.Fill();
                    //this.label1.Size = new System.Drawing.Size(35, 13);
                    //flowLayoutPanel1.Controls.Add(item);
                    //flowLayoutPanel1.SetFlowBreak(item, true);
                }

                this.Refresh();
            }


        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            //foreach (RecipeNode me in this.flowLayoutPanel1.Controls)
            //{
            //    foreach (RecipeNode him in me.IncomingRecipes)
            //    {
            //        Point pMe = new Point(me.Location.X + me.Size.Width / 2, me.Location.Y + me.Size.Height / 2);
            //        Point pHim = new Point(him.Location.X + him.Size.Width / 2, him.Location.Y + him.Size.Height / 2);
            //        e.Graphics.DrawLine(pen, pMe.X,pMe.Y,pHim.X,pHim.Y);
            //    }
              
            //}
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
            //nodes = nodes.OrderByDescending(_ => Helper.GetTreeSize(_));
            var roots = nodes.Where(_ => _.IncomingRecipes.Count == 0).OrderByDescending(_ => Helper.GetTreeSize(_));

            tlp.RowCount = 10;
            tlp.ColumnCount = 10;
            //tlp.Controls.Add(new Button(), 0, 0);
            foreach (var item in roots)
            {
                var position = (int)Math.Ceiling(item.OutGoingRecipes.Count / 2.0f);
                var controlsFromSameRow = tlp.GetControlsFromRow(1);
                if (controlsFromSameRow.Any())
                {
                    var mostRightInColumnColIndex = controlsFromSameRow.Max(_ => tlp.GetColumn(_));
                    var mostRightInColumn = tlp.GetControlFromPosition(mostRightInColumnColIndex, 0) as RecipeNode;
                    /*1*/
                    position += mostRightInColumnColIndex + (int)Math.Floor(mostRightInColumn.OutGoingRecipes.Count / 2.0f);
                }
                item.Fill();
                tlp.Controls.Add(item, position, 0);


            }
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

        public static void GetRowFromControl(this Control control,TableLayoutPanel panel)
        {

        }


    }


}
