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
        public static void ChartTree(IEnumerable<RecipeNode> nodes, TableLayoutPanel tlp)
        {
            var roots = nodes.Where(_ => _.IncomingRecipes.Count == 0).OrderByDescending(_ => Helper.GetTreeSize(_));

            //m(tlp, roots,);
        }

        private static void m(TableLayoutPanel tlp, IEnumerable<RecipeNode> roots, int parentRow, int parentColumn)
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



            q = (node, path) =>
            {
                foreach (var item in node.OutGoingRecipes)
                {
                    if (path.Contains(item))
                        continue;

                    path.Push(item);
                    if (endNodes.Contains(item))
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

        public static decimal GetQuantityv1(List<RecipeNode> recipes, string startingResource, int startingResourceQuantity, string endingResource)
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

        public static decimal GetQuantityv2(List<RecipeNode> pathRecipes, List<RecipeNode> allAvailableRecipes, ResourceChunk startingResource, string endingResource)
        {
            var currentResources = new List<ResourceChunk>();
            currentResources.Add(startingResource);

            Func<decimal, int, int> getRes = (recipeQuantity, timesRecipeUsage) =>
            {
                var r = new Random();
                return 0;
            };


            while (true)
            {
                //get recipes that uses resource that I currently have 
                var r = pathRecipes
                    .Where(a => a.Recipe.Inputs
                        .Any(b => currentResources
                            .Any(c => b.Name == c.Name)))
                    .Where(recipe => recipe.Recipe.Inputs
                            .Where(b => currentResources
                                .Any(c => b.Name == c.Name))
                        .All(b => b.Quantity <= recipe.Recipe.Inputs
                            .First(d =>d.Name == b.Name).Quantity))
                    .FirstOrDefault();

                if (r == null)
                {
                    r = allAvailableRecipes.FirstOrDefault(a => a.Recipe.Inputs.Any(b => currentResources.Any(c => b.Name == c.Name)));

                    if (r == null)
                        break;
                }

                var resourceChunkToUseAsInput = currentResources.First(a => r.Recipe.Inputs.Any(b => a.Name == b.Name));
                var timesRecipeUsage = Math.Floor(
                    resourceChunkToUseAsInput.Quantity / r.Recipe.Inputs.First(a => a.Name == resourceChunkToUseAsInput.Name).Quantity);


                currentResources.Remove(resourceChunkToUseAsInput);
                foreach (var item in r.Recipe.Outputs)
                {
                    try
                    {
                        var addedResource = item.Quantity == Math.Round(item.Quantity)
                            ? item.Quantity * timesRecipeUsage
                            :0;


                        var q = currentResources.FirstOrDefault(_ => _.Name == item.Name);

                        if (q != null)
                            q.Quantity += item.Quantity * timesRecipeUsage;
                        else
                            currentResources.Add(new ResourceChunk() { Name = item.Name, Quantity = item.Quantity * timesRecipeUsage });

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                foreach (var item in currentResources)
                {
                    item.Quantity = Math.Round(item.Quantity,3);
                }

                currentResources.RemoveAll(_ => _.Quantity == 0);
            }

            var sb = new StringBuilder();
            foreach (var item in currentResources)
            {
                sb.AppendLine($"{item.Quantity} {item.Name}");
            }
            MessageBox.Show(sb.ToString());

            return currentResources.First(a => a.Name == endingResource).Quantity;
        }
    }
}
