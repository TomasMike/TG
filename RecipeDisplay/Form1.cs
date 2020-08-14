using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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

        private enum Types
        {
            Chrome,
            Zinc
        }

        private void be()
        {
            Class1.Start();
            return;

            var root = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@"C:\Users\tmi\Downloads\f.txt"));
            //var root = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@"C:\Downloads\f.txt"));
            List<Recipee> rec = new List<Recipee>();

            foreach (Recipe node in root.recipes)
            {
                var r = new Recipee();
                if (
                    node.name.IndexOf("void") >= 0
                    || node.name.IndexOf("crate") >= 0
                    || node.name.IndexOf("stack") >= 0
                    || node.name.IndexOf("barrel") >= 0
                    || node.name.IndexOf("delivery") >= 0
                    || node.name.IndexOf("pack") >= 0
                    || node.name.IndexOf("blackhole") >= 0
                    )
                    continue;
                r.Name = node.name;
                foreach (Ingredient child in node.ingredients)
                {
                    var m = new ResourceChunk()
                    {
                        Name = child.name,
                        Quantity = child.amount,
                    };

                    r.Inputs.Add(m);
                }

                foreach (Product child in node.products)
                {
                    var m = new ResourceChunk()
                    {
                        Name = child.name,
                        Quantity = child.amount,
                        Probability = child.probability
                    };

                    r.Outputs.Add(m);
                }
                rec.Add(r);


            }

            List<RecipeNode> labels = new List<RecipeNode>();

            foreach (Recipee re in rec)
            {
                var r = new RecipeNode()
                {
                    Recipe = re
                };
                labels.Add(r);
            }

          


            labels = getMostEfficientPath(labels,"titanium", "ore-titanium", "titanium-plate", 1000);
            //labels = getMostEfficientPath(labels);
        }

        private static List<RecipeNode> getMostEfficientPath(List<RecipeNode> labels,string keyWord,string startingResource,string endingResource,int amount)
        {
            //labels = labels.Where(_ => _.Recipe.Outputs.Any(__ => __.Name.IndexOf(keyWord) >= 0)).ToList();
            //foreach (var item in labels.Where(_ => _.Recipe.Outputs.Any(__ => __.Name.IndexOf(keyWord) >= 0))
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
            //var q = labels.Where(_ => _.Recipe.Inputs.Any(a => a.Name.IndexOf("copper-ore") >= 0));

            FindOptimalProductionPath(null, startingResource, endingResource, amount, labels);
            return labels;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //be();

            if (false)
            {
                RecipeNodeUC r = new RecipeNodeUC()
                {
                    Recipe = new Recipee()
                    {
                        Inputs = new List<ResourceChunk>()
                    {
                        new ResourceChunk(){Name ="iron-ore",Probability =1,Quantity = 1}
                    },
                        Outputs = new List<ResourceChunk>()
                    {
                        new ResourceChunk(){Name ="iron-plate",Probability =1,Quantity = 1}
                    }
                    },
                    Name = "iron-ore-to-iron-plate"
                };
                r.Fill();
                this.Controls.Add(r);
                //r.Size = new Size(50, 50);
            }
            else
                DisplayRecipes();

            return;


            #region MyRegion
            //this.Paint += Form1_Paint;
            //this.AutoSize = true;
            //List<RecipeNode> labels = InitRecipes("Chrome");

            //var choosenResource = Types.Chrome;
            //Stack<RecipeNode> x;
            //switch (choosenResource)
            //{
            //    case Types.Chrome: 
            //        x = FindOptimalProductionPath("Chrome","Chromium Ore","Chromium Ingot",1000);
            //        break;
            //    case Types.Zinc:
            //        x = FindOptimalProductionPath("Zinc", "Zinc Ore", "Zinc Ingot", 1000);
            //        break;
            //    default:
            //        break;
            //}

            //if (false)
            //{

            //    var roots = labels.Where(_ => _.IncomingRecipes.Count == 0);

            //    Action<IEnumerable<RecipeNode>> d = null;

            //    d = n =>
            //    {

            //        if (n.Count() == 0)
            //            return;

            //        var controlsAdded = new List<RecipeNodeUC>();
            //        foreach (var item in n)
            //        {
            //            item.AutoSize = true;
            //            item.Fill();

            //            if (item.Recipe.Name == "ble")
            //            {
            //                item.BackColor = Color.Green;
            //            }
            //            if (!flowLayoutPanel1.Controls.Contains(item))
            //            {
            //                flowLayoutPanel1.Controls.Add(item);
            //                controlsAdded.Add(item);
            //            }
            //        }

            //        if (flowLayoutPanel1.Controls.Count > 0)
            //            flowLayoutPanel1.SetFlowBreak(flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1], true);


            //        foreach (var item in controlsAdded)
            //        {
            //            d(item.OutGoingRecipes);
            //        }
            //    };

            //    d(roots);

            //}
            //else
            //{
            //    flowLayoutPanel1.Hide();

            //    var t = new TableLayoutPanel();
            //    t.RowCount = 10;
            //    t.ColumnCount = 10;
            //    for (int i = 0; i < 10; i++)
            //    {
            //        //t.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            //        //t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            //        t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //        t.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            //    }

            //    t.Dock = DockStyle.Fill;
            //    t.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;


            //    t.BackColor = Color.Beige;
            //    TreeCharter.ChartTree(labels, t);
            //    this.Controls.Add(t);
            //    this.Refresh();

            //}

            //this.flowLayoutPanel1.Paint += Form1_Paint; 
            #endregion


        }

        private void DisplayRecipes()
        {
            //vytvor nodes
            var recipes = Class1.LoadRecipes().Select(_ => new RecipeNode() { Recipe = _ }).ToList();
            var labels = recipes.Select(_ => new RecipeNodeUC() { Recipe = _.Recipe });
            var q = File.ReadAllText(Path.Combine(Class1.SaveFolder, $"ore-titanium_titanium-plate_include.txt")).Split(',');
            var recipeNodesToUse = labels.Where(_ => q.Contains(_.Recipe.Name)).ToList();
            
            //napln income outcome recipe
            foreach (var item in recipeNodesToUse)
            {
                foreach (var input in item.Recipe.Inputs)
                {
                    foreach (var matchedRecipeLabel in recipeNodesToUse.Where(_ => _.Recipe.Outputs.Any(__ => __.Name == input.Name)))
                    {
                        item.IncomingRecipes.Add(matchedRecipeLabel);
                    }
                }

                foreach (var output in item.Recipe.Outputs)
                {
                    foreach (var matchedRecipeLabel in recipeNodesToUse.Where(_ => _.Recipe.Inputs.Any(__ => __.Name == output.Name)))
                    {
                        item.OutGoingRecipes.Add(matchedRecipeLabel);
                    }
                }
            }

            //najdi startovne koncove node
            var startResourceName = "ore-titanium";
            var endResourceName = "titanium-plate";
            var startNodes = recipeNodesToUse.Where(_ => _.Recipe.Inputs.Any(__ => __.Name == startResourceName));
            var endNodes = recipeNodesToUse.Where(_ => _.Recipe.Outputs.Any(__ => __.Name == endResourceName));

            var colcount =(int)Math.Round(Math.Sqrt(recipeNodesToUse.Count()));
            var padding = 10;

            for (int i = 0; i < recipeNodesToUse.Count(); i++)
            {

                var item = recipeNodesToUse[i];
                this.Controls.Add(item);
                item.Fill();

                item.gridRow = i == 0 ? 0 : (int)Math.Floor((decimal)(i / colcount));
                item.gridColumn = i % colcount;

                //item.Location = new Point()

            }



            //this.Controls

            //startNodes.ToList()[0].gridRow
        }

        private static Stack<RecipeNode> FindOptimalProductionPath(string fileName, string startingResourceName, string endingResourceName, int startingInputQuantity, IEnumerable<RecipeNode> recipes = null)
        {
            IEnumerable<RecipeNode> labels = recipes ?? InitRecipes(fileName);
            //TreeCharter.FindPathsv2(labels, startingResourceName, endingResourceName);
            var x = TreeCharter.FindPathsv1(labels, startingResourceName, endingResourceName);
            var pathsYield = new List<Tuple<decimal, Stack<RecipeNode>,string>>();
            foreach (var item in x)
            {
                var q = TreeCharter.GetQuantityv2(item.ToList(), labels.ToList(), new ResourceChunk() { Name = startingResourceName, Quantity = startingInputQuantity }, endingResourceName);
                pathsYield.Add(new Tuple<decimal, Stack<RecipeNode>,string>(q.Item1, item,q.Item2));
            }
            var orderedYields = pathsYield.OrderByDescending(_ => _.Item1).ToList();

            var best = orderedYields.First();
            return best.Item2;
        }

        private static List<RecipeNode> InitRecipes(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetFullPath(Path.Combine(Application.StartupPath, $@"..\..\{fileName}.xml")));

            var recipes = new List<Recipee>();

            foreach (XmlNode node in doc.SelectNodes("//recipe"))
            {
                var r = new Recipee();
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

            foreach (Recipee rec in recipes)
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
            //var g = e.Graphics;
            //Pen pen = new Pen(Color.Black);
            //pen.Width = 4;
            //foreach (RecipeNodeUC me in this.flowLayoutPanel1.Controls)
            //{
            //    foreach (RecipeNodeUC him in me.IncomingRecipes)
            //    {
            //        Point pMe = new Point(me.Location.X + me.Size.Width / 2, me.Location.Y + me.Size.Height / 2);
            //        Point pHim = new Point(him.Location.X + him.Size.Width / 2, him.Location.Y + him.Size.Height / 2);
            //        g.DrawLine(pen, pMe.X, pMe.Y, pHim.X, pHim.Y);
            //    }

            //}
        }
    }

    #region classesForJSONDeserialize
    public class Ingredient
    {
        public int amount { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double? maximum_temperature { get; set; }
        public double? minimum_temperature { get; set; }
    }

    public class Product
    {
        public int amount { get; set; }
        public string name { get; set; }
        public double probability { get; set; }
        public string type { get; set; }
        public int? temperature { get; set; }
    }

    public class Recipe
    {
        public string category { get; set; }
        public double energy { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public string name { get; set; }
        public List<Product> products { get; set; }
    }

    public class Root
    {
        public List<Recipe> recipes { get; set; }
    } 
    #endregion




    [DebuggerDisplay("{getDebugText}")]
    public class Recipee
    {
        [NonSerialized]
        public List<ResourceChunk> Inputs = new List<ResourceChunk>();

        [NonSerialized]
        public List<ResourceChunk> Outputs = new List<ResourceChunk>();
        public string Name;
        public string getDebugText => $"{string.Join(",", Inputs)}=>{string.Join(",", Outputs)}";
    }

    public class ResourceChunk
    {
        public string Name;
        public decimal Quantity;
        public double Probability;

        public override string ToString()
        {
            return $"{Quantity}x {Name}";
        }
    }

    public static class Helper
    {
        public static int GetTreeSize(RecipeNodeUC node)
        {
            var nodes = new List<RecipeNodeUC>();

            Action<RecipeNodeUC> a = null;
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

    public interface IRecipeContainer
    {
        Recipee GetRecipe();
        List<RecipeNode> GetIncomingRecipes();
        List<RecipeNode> GetOutGoingRecipes();
    }
}
