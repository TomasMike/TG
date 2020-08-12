using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecipeDisplay
{
    public static class TreeCharter
    {
        public static List<string> IgnoredInputs = new List<string>()
        {
            "hot-air",
            "salt",
            "water",
            "acid-solvent",
            "borax",
            "oxygen",
            "sand-casting",
            "sodium-sulfate",
            "diesel",
            "pressured-air",
            "lime",
            "syngas",
            "grease",
            "y_block_heat",
            "y_toolhead"
        };

        private static List<string> MissingNotIgnoredResourcesReportedThisSession = new List<string>();


        public static void ChartTree(IEnumerable<RecipeNodeUC> nodes, TableLayoutPanel tlp)
        {
            var roots = nodes.Where(_ => _.IncomingRecipes.Count == 0).OrderByDescending(_ => Helper.GetTreeSize(_));

            //m(tlp, roots,);
        }

        private static void m(TableLayoutPanel tlp, IEnumerable<RecipeNodeUC> roots, int parentRow, int parentColumn)
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

        public static List<Stack<RecipeNode>> FindPathsv1(IEnumerable<RecipeNode> nodes, string recipeFrom, string recipeTo)
        {
            var foundPaths = new List<Stack<RecipeNode>>();
            Action<RecipeNode, Stack<RecipeNode>> q = null;

            var startNodes = nodes.Where(_ => _.Recipe.Inputs.Any(__ => __.Name == recipeFrom));
            var endNodes = nodes.Where(_ => _.Recipe.Outputs.Any(__ => __.Name == recipeTo));

            var includeRecipes = new List<string>();
            var excludedRecipes = new List<string>();



            q = (node, path) =>
            {
                foreach (var item in node.OutGoingRecipes)
                {
                    if(includeRecipes.Contains(item.Recipe.Name))
                    {

                    }
                    else if(excludedRecipes.Contains(item.Recipe.Name))
                    {
                        continue;
                    }
                    else
                    {
                        if(MessageBox.Show($@"Include this recipe?[{item.Recipe.getDebugText}]","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            includeRecipes.Add(item.Recipe.Name);
                        }
                        else
                        {
                            excludedRecipes.Add(item.Recipe.Name);
                            continue;
                        }
                    }

                    if (path.Contains(item))
                        continue;

                    path.Push(item);
                    if (endNodes.Contains(item))
                    {
                        foundPaths.Add(new Stack<RecipeNode>(path));
                    }
                    else if(path.Count <= 50)
                        q(item, path);

                    path.Pop();

                }
            };

            foreach (var item in startNodes)
            {
                var p = new Stack<RecipeNode>();
                p.Push(item);

                if (endNodes.Contains(item))
                    foundPaths.Add(new Stack<RecipeNode>(p));
                else
                    q(item, p);
            }



            return foundPaths;
        }

        public static void FindPathsv2(IEnumerable<RecipeNode> nodes, string recipeFrom, string recipeTo)
        {
            var inputs = new Dictionary<string, int>();
            foreach (var recipe in nodes)
            {
                foreach (var input in recipe.Recipe.Inputs)
                {
                    if (inputs.ContainsKey(input.Name))
                        inputs[input.Name]++;
                    else
                        inputs.Add(input.Name, 1);
                }
            }

            foreach (var item in inputs.Where(_ => _.Value > 1))
            {

            }
        }

        public static decimal GetQuantityv1(List<RecipeNodeUC> recipes, string startingResource, int startingResourceQuantity, string endingResource)
        {
            decimal currentQuantity = startingResourceQuantity;
            string currentResource = startingResource;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < recipes.Count; i++)
            {
                if (currentResource == endingResource)
                    break;

                var currentRecipe = recipes[i];

                var nextResource = currentRecipe.Recipe.Outputs.Any(_ => _.Name == endingResource)
                    ? endingResource
                    : recipes[i + 1].Recipe.Inputs.First(_ => currentRecipe.Recipe.Outputs.Any(__ => __.Name == _.Name)).Name;

                var recipeInputQuantity = currentRecipe.Recipe.Inputs.First(_ => _.Name == currentResource).Quantity;
                var recipeOutputQuantity = currentRecipe.Recipe.Outputs.First(_ => _.Name == nextResource).Quantity;

                var newQuantity = (currentQuantity / recipeInputQuantity) * recipeOutputQuantity;
                sb.AppendLine($"{currentQuantity} {currentResource} to {newQuantity} {nextResource}");

                currentQuantity = newQuantity;
                currentResource = nextResource;
            }




            MessageBox.Show(sb.ToString());
            return currentQuantity;
        }

        public static Tuple<decimal,string> GetQuantityv2(List<RecipeNode> pathRecipes, List<RecipeNode> allAvailableRecipes, ResourceChunk startingResource, string endingResource)
        {
            var simulateChanceBasedRecipes = false;

            var currentResources = new List<ResourceChunk>();
            currentResources.Add(startingResource);

            Func<double, int, decimal> getRes = (recipeQuantity, timesRecipeUsage) =>
            {
                if (simulateChanceBasedRecipes)
                {
                    var r = new Random();
                    var retVal = 0;
                    for (int i = 0; i < timesRecipeUsage; i++)
                    {
                        if (r.Next(1, 101) <= recipeQuantity * 100)
                            retVal++;
                    }

                    return retVal;
                }

                return Convert.ToDecimal(recipeQuantity * timesRecipeUsage);

            };


            var sb = new StringBuilder();

            int j = 0;
            while (true)
            {
                j++;
                if (j > 20)
                {
                    var x = 3;
                }
                var recipesICanUse = new List<RecipeNode>();

                foreach (var availableRecipe in pathRecipes)
                {
                    if (availableRecipe.Recipe.Inputs.Any(a => a.Name == endingResource))
                        continue;

                    //ak aspon jeden input mam a mam ho dost
                    if (availableRecipe.Recipe.Inputs
                        .Any(input => currentResources
                            .Any(cr =>
                                cr.Name == input.Name
                                && cr.Quantity >= input.Quantity))
                        )
                    {
                        if (availableRecipe.Recipe.Inputs.All(input =>
                        {
                            //ak aspon jeden input mam a mam ho dost
                            if (currentResources.FirstOrDefault(a => a.Name == input.Name && a.Quantity >= input.Quantity) != null)
                                return true;

                            //ak je to zdroj co mozem ziskat inym receptom
                            //if (pathRecipes.Any(a => a.Recipe.Outputs.Any(b => b.Name == input.Name))) return false;

                            if(IgnoredInputs.Contains(input.Name))
                            {
                                return true;
                            }
                            else
                            {
                                //ak app uz informovala ze nemam surku a dal som ok, je to ocakavana chybajuca surka vramci pouzivanych receptov
                                if(MissingNotIgnoredResourcesReportedThisSession.Contains(input.Name))
                                {
                                    return false;
                                }

                                //MessageBox.Show($"nemam {input.Name}");

                                MissingNotIgnoredResourcesReportedThisSession.Add(input.Name);
                                return false;
                            }

                            //return true;

                        }))
                        {
                            recipesICanUse.Add(availableRecipe);
                            break;
                        }
                    }
                }
                var recipeToUse = recipesICanUse.FirstOrDefault();
                if (recipeToUse == null) break;

                var resourceChunkToUseAsInput = currentResources.First(a => recipeToUse.Recipe.Inputs.Any(b => a.Name == b.Name));

                var recipeInputChunk = recipeToUse.Recipe.Inputs.First(a => a.Name == resourceChunkToUseAsInput.Name);

                int timesRecipeUsage = (int)Math.Floor(resourceChunkToUseAsInput.Quantity / recipeInputChunk.Quantity);
                sb.AppendLine($"{timesRecipeUsage}[{string.Join(",", recipeToUse.Recipe.Inputs)} to {string.Join(",", recipeToUse.Recipe.Outputs)}]");

                var totalInputUsed = timesRecipeUsage * recipeInputChunk.Quantity;

                resourceChunkToUseAsInput.Quantity -= totalInputUsed;

                foreach (var item in recipeToUse.Recipe.Outputs)
                {

                    var addedResource = item.Quantity == Math.Round(item.Quantity)
                        ? item.Quantity * timesRecipeUsage
                        : getRes(item.Probability, timesRecipeUsage);

                    var q = currentResources.FirstOrDefault(_ => _.Name == item.Name);

                    if (q != null)
                        q.Quantity += item.Quantity * timesRecipeUsage;
                    else
                        currentResources.Add(new ResourceChunk() { Name = item.Name, Quantity = item.Quantity * timesRecipeUsage });


                }

                foreach (var item in currentResources)
                {
                    item.Quantity = Math.Round(item.Quantity, 3);
                }

                currentResources.RemoveAll(_ => _.Quantity == 0);
            }

            sb.AppendLine();
            foreach (var item in currentResources)
            {
                sb.AppendLine($"{item.Quantity} {item.Name}");
            }
            //MessageBox.Show(sb.ToString());

            if (!currentResources.Any(a => a.Name == endingResource))
            {
                var q = 2;
            }

            return new Tuple<decimal,string>(currentResources.FirstOrDefault(a => a.Name == endingResource)?.Quantity ?? 0,sb.ToString());
        }
    }
}
