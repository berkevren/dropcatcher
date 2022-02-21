using DropCatcher.DataModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace DropCatcher.CustomDropCatchers.StockBasedDropCatchers
{
    public class YuyuteiDropCatcher : StockBasedDropCatcher
    {
        private const string AlarmMessageYuyutei = "Yuyu Tay Drop! Yuyu Tay Drop! Yuyu Tay Drop!";
        private const string EmailSubject  = "Yuyutei Drop!";

        private readonly string[] productNames;
        private List<string> foundProductNames;

        public YuyuteiDropCatcher(
            string[] targetDivs,
            string targetUrl,
            YuyuteiProduct[] products)
            : base(
                  targetDivs,
                  GetIds(products),
                  targetUrl,
                  AlarmMessageYuyutei,
                  EmailSubject)
        {
            if (products == null)
            {
                throw new FormatException("null products!");
            }

            productNames = new string[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                productNames[i] = products[i].Name;
            }

            foundProductNames = new();
        }

        protected override List<string> GetInStockProductsFromNodes(HtmlNodeCollection nodes)
        {
            var inStockProducts = new List<string>();

            foreach (var rateNode in nodes)
            {
                for (int i = 0; i < this.ThingsToLookOutFor.Length; i++)
                {
                    if (rateNode.InnerText.Contains(this.ThingsToLookOutFor[i])
                        && IsProductInStock(rateNode))
                    {
                        if (!foundProductNames.Contains(productNames[i]))
                        {
                            foundProductNames.Add(productNames[i]);
                            inStockProducts.Add(productNames[i]);
                        }
                        
                        break;
                    }
                }
            }

            return inStockProducts;
        }

        private static string[] GetIds(YuyuteiProduct[] products)
        {
            var ids = new string[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                ids[i] = products[i].Id;
            }

            return ids;
        }

        private bool IsProductInStock(HtmlNode node)
        {
            return node.ChildNodes[5].InnerHtml.Contains("btn_sold_out.png");
        }
    }
}
