using DropCatcher.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DropCatcher.CustomDropCatchers.StockBasedDropCatchers
{
    public class YuyuteiDropCatcher : StockBasedDropCatcher
    {
        private const string FileLoggerPath = "C:/Users/berka/Documents/YuyuteiProductList.txt";
        private const string AlarmSoundPath = "C:/Users/berka/Documents/yuyuteidrop.wav";
        private const string AlarmMessageSubject = "New Yuyutei Drop!";

        private readonly string[] productNames;

        public YuyuteiDropCatcher(
            string[] targetDivs,
            string targetUrl,
            YuyuteiProduct[] products)
            : base(GetIds(products))
        {
            if (products == null)
            {
                throw new FormatException("null products!");
            }

            this.TargetUrl = targetUrl;
            this.DivClasses = targetDivs;
            this.FileLogger = new FileLogger(path: FileLoggerPath);
            this.AlarmSounder = new AlarmSounder(
                alarmSoundPath: AlarmSoundPath,
                linkToProducts: this.TargetUrl,
                messageSubject: AlarmMessageSubject);

            productNames = new string[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                productNames[i] = products[i].Name;
            }
        }

        protected override List<string> GetInStockProductsFromNodes(HtmlAgilityPack.HtmlNodeCollection nodes)
        {
            var inStockProducts = new List<string>();

            foreach (var rateNode in nodes)
            {
                for (int i = 0; i < this.ThingsToLookOutFor.Length; i++)
                {
                    if (rateNode.InnerText.Contains(this.ThingsToLookOutFor[i])
                        && IsProductInStock(rateNode))
                    {
                        inStockProducts.Add(productNames[i]);
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

        private bool IsProductInStock(HtmlAgilityPack.HtmlNode node)
        {
            return !node.ChildNodes[5].InnerHtml.Contains("btn_sold_out.png");
        }
    }
}
