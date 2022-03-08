using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class ListingBasedDropCatcher : HTMLDropCatcher
    {
        public int NumberOfProductsOnTargetUrl { get; protected set; }

        public FileLogger FileLogger { get; protected set; }

        private List<string> FoundProducts { get; set; }

        public ListingBasedDropCatcher(
            string targetDiv,
            string[] thingsToLookOutFor,
            int numberOfProductsOnTargetUrl,
            string targetUrl,
            string alarmMessage,
            string emailSubject)
            : base(
                  new string[] { targetDiv },
                  thingsToLookOutFor,
                  targetUrl,
                  alarmMessage,
                  emailSubject)
        {
            this.NumberOfProductsOnTargetUrl = numberOfProductsOnTargetUrl;
            this.FoundProducts = new List<string>();
        }

        // Gets the products from a target url and returns all the products as a file-ready string.
        protected override string FindProductsFromNodes(HtmlAgilityPack.HtmlNodeCollection nodes)
        {
            var products = new List<string>();

            foreach (var rateNode in nodes)
            {
                products.Add(rateNode.InnerText);
            }

            var fileFormattedProducts = this.ToFileFormat(products);
            // if there is a goal product, only sound the horns if it is found
            if (this.ThingsToLookOutFor != null
                && this.ThingsToLookOutFor.Length > 0
                && this.GoalProductIsFound(fileFormattedProducts, this.ThingsToLookOutFor)
                && this.IncludesNewProduct(products))
            {
                return fileFormattedProducts;
            }

            return string.Empty;
        }

        protected override void AssertAllFieldsAreValid()
        {
            if (this.NumberOfProductsOnTargetUrl <= 0)
            {
                throw new FormatException("NumberOfProductsOnTargetUrl must be > 0!");
            }

            base.AssertAllFieldsAreValid();
        }

        private bool IncludesNewProduct(List<string> latestProducts)
        {
            var newProductsFound = !this.FoundProducts.SequenceEqual(latestProducts);
            this.FoundProducts = latestProducts;
            return newProductsFound;
        }
    }
}
