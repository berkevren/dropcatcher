using System;
using System.Collections.Generic;
using System.Text;

namespace DropCatcher.CustomDropCatchers.StockBasedDropCatchers
{
    public class StockBasedDropCatcher : DropCatcher
    {
        public StockBasedDropCatcher(
            string[] thingsToLookOutFor,
            string alarmMessage)
            : base(
                  thingsToLookOutFor,
                  alarmMessage)
        {
        }

        protected override string FindProductsFromNodes(HtmlAgilityPack.HtmlNodeCollection nodes)
        {
            var inStockProducts = this.GetInStockProductsFromNodes(nodes);

            if (inStockProducts.Count > 0)
            {
                var formattedInStockProducts = this.ToFileFormat(inStockProducts);
                this.FileLogger.WriteToFile("\nIN STOCK PROCUTS - " + formattedInStockProducts);
                return formattedInStockProducts;
            }

            return string.Empty;
        }

        protected virtual List<string> GetInStockProductsFromNodes(HtmlAgilityPack.HtmlNodeCollection nodes)
        {
            return new List<string>();
        }
    }
}
