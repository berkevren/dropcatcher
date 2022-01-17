using System;
using System.Collections.Generic;
using System.Text;

namespace DropCatcher.CustomDropCatchers.StockBasedDropCatchers
{
    public class StockBasedDropCatcher : DropCatcher
    {
        private readonly string[] explanations;

        public StockBasedDropCatcher(
            string[] thingsToLookOutFor,
            string[] explanations)
            : base(thingsToLookOutFor)
        {
            this.explanations = explanations;
        }

        public void CheckForProducts()
        {
            this.AssertAllFieldsAreValid();

            var nodes = this.GetNodesFromTargetUrl();

            if (nodes == null)
            {
                return;
            }

            var inStockProducts = new List<string>();

            foreach (var rateNode in nodes)
            {
                for (int i = 0; i < this.ThingsToLookOutFor.Length; i++)
                {
                    if (rateNode.InnerText.Contains(this.ThingsToLookOutFor[i]))
                    {
                        if (!rateNode.ChildNodes[5].InnerHtml.Contains("btn_sold_out.png"))
                        {
                            inStockProducts.Add(explanations[i]);
                        }
                    }
                }
            }

            if (inStockProducts.Count > 0)
            {
                var formattedInStockProducts = this.ToFileFormat(inStockProducts);
                this.SoundTheHornsAndSendTheRavens(formattedInStockProducts);
                this.FileLogger.WriteToFile("\nIN STOCK PROCUTS - " + formattedInStockProducts);
            }
        }
    }
}
