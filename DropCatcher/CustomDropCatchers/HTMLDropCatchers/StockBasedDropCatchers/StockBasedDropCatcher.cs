﻿using System.Collections.Generic;

namespace DropCatcher.CustomDropCatchers.StockBasedDropCatchers
{
    public abstract class StockBasedDropCatcher : HTMLDropCatcher
    {
        public StockBasedDropCatcher(
            string[] targetDivs,
            string[] thingsToLookOutFor,
            string targetUrl,
            string alarmMessageSubject,
            string emailSubject)
            : base(
                  targetDivs,
                  thingsToLookOutFor,
                  targetUrl,
                  alarmMessageSubject,
                  emailSubject)
        {
        }

        protected override string FindProductsFromNodes(HtmlAgilityPack.HtmlNodeCollection nodes)
        {
            var inStockProducts = this.GetInStockProductsFromNodes(nodes);

            if (inStockProducts.Count > 0)
            {
                var formattedInStockProducts = this.ToFileFormat(inStockProducts);
                return formattedInStockProducts;
            }

            return string.Empty;
        }

        protected abstract List<string> GetInStockProductsFromNodes(HtmlAgilityPack.HtmlNodeCollection nodes);
    }
}
