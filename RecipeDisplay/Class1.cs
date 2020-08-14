using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RecipeDisplay
{
    public static class Class1
    {

        public static string  SaveFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\SaveFiles"));

        public static void Start()
        {
            var recipes = LoadRecipes().Select(_ => new RecipeNode() { Recipe = _}).ToList();
            foreach (var item in recipes)
            {
                foreach (var input in item.Recipe.Inputs)
                {
                    foreach (var matchedRecipeLabel in recipes.Where(_ => _.Recipe.Outputs.Any(__ => __.Name == input.Name)))
                    {
                        item.IncomingRecipes.Add(matchedRecipeLabel);
                    }
                }

                foreach (var output in item.Recipe.Outputs)
                {
                    foreach (var matchedRecipeLabel in recipes.Where(_ => _.Recipe.Inputs.Any(__ => __.Name == output.Name)))
                    {
                        item.OutGoingRecipes.Add(matchedRecipeLabel);
                    }
                }
            }
            FindOptimalProductionPath(recipes, "ore-titanium", "titanium-plate", 1000);
        }



        private static Stack<RecipeNode> FindOptimalProductionPath(IEnumerable<RecipeNode> recipes, string startingResourceName, string endingResourceName, int startingInputQuantity)
        {
            IEnumerable<RecipeNode> labels = recipes;
            var x = TreeCharter.FindPathsv1(labels, startingResourceName, endingResourceName);
            var pathsYield = new List<Tuple<decimal, Stack<RecipeNode>, string>>();
            
            foreach (var item in x)
            {
                var q = TreeCharter.GetQuantityv2(item.ToList(), labels.ToList(), new ResourceChunk() { Name = startingResourceName, Quantity = startingInputQuantity }, endingResourceName);
                pathsYield.Add(new Tuple<decimal, Stack<RecipeNode>, string>(q.Item1, item, q.Item2));
            }

            var orderedYields = pathsYield.OrderByDescending(_ => _.Item1).ToList();

            var best = orderedYields.First();
            return best.Item2;
        }

        public static List<Recipee> LoadRecipes()
        {
            var serializer = new XmlSerializer(typeof(List<Recipee>));
            using (FileStream fs = new FileStream(@"C:\Users\tmi\Downloads\f_xml.xml", FileMode.Open))
            {
                TextReader reader = new StreamReader(fs);
                return (List<Recipee>)serializer.Deserialize(reader);
            }
        }

        public static void ParseJsonFileToXMLFile()
        {
            //load all json recipes
            var root = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@"C:\Users\tmi\Downloads\f.txt"));
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

            //rec. Distinct(a => a.)


            XmlSerializer writer = new XmlSerializer(rec.GetType());
            var path = @"C:\Users\tmi\Downloads\f_xml.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, rec);
            }

        }
    }
}
