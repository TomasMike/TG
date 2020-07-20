using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\XMLFile1.xml")));
            this.Paint += Form1_Paint;

            var recipes = new List<Recipe>();

            foreach(XmlNode node in doc.SelectNodes("//recipe"))
            {
                var r = new Recipe();

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
                    Recipe= rec
                };
                labels.Add(r);
            }

            foreach (var item in labels)
            {
                foreach(var input in item.Recipe.Inputs)
                {
                    foreach(var matchedRecipeLabel in  labels.Where(_ => _.Recipe.Outputs.Any(__ => __.Name == input.Name)))
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

            labels.OrderByDescending(_ => _.IncomingRecipes.Count);

            foreach (var item in labels)
            {
               
                item.AutoSize = true;
                item.Fill();
                //this.label1.Size = new System.Drawing.Size(35, 13);
                flowLayoutPanel1.Controls.Add(item);
                //flowLayoutPanel1.SetFlowBreak(item, true);
            }

            this.Refresh();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            
            foreach (RecipeNode me in this.flowLayoutPanel1.Controls)
            {
                foreach (RecipeNode him in me.IncomingRecipes)
                {
                    e.Graphics.DrawLine(pen, me.Location.X,me.Location.Y,him.Location.X,him.Location.Y);
                }
                foreach (RecipeNode him in me.OutGoingRecipes)
                {
                    e.Graphics.DrawLine(pen, me.Location.X, me.Location.Y, him.Location.X, him.Location.Y);
                }
            }

          
        }
    }



    public class Recipe
    {
        public List<RecipePart> Inputs = new List<RecipePart>();
        public List<RecipePart> Outputs = new List<RecipePart>();

    }

    public class RecipePart
    {
        public string Name;
        public float Quantity;
    }

}
