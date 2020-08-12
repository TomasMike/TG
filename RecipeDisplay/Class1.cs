using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeDisplay
{
    public static class Class1
    {
        public static void Start()
        {
            var recipes = LoadRecipes();


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
