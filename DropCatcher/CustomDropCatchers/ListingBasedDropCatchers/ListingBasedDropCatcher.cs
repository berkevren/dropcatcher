using System;
using System.Collections.Generic;
using System.Text;

namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class ListingBasedDropCatcher : DropCatcher
    {
        public int NumberOfProductsOnTargetUrl { get; protected set; }

        public ListingBasedDropCatcher(
            string[] thingsToLookOutFor,
            int numberOfProductsOnTargetUrl,
            string targetDiv)
            : base(thingsToLookOutFor)
        {
            this.DivClasses = new string[] { targetDiv };
            this.NumberOfProductsOnTargetUrl = numberOfProductsOnTargetUrl;
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
            if (this.FileLogger.WriteFileIfNewProductIsFound(fileFormattedProducts, this.NumberOfProductsOnTargetUrl))
            {
                // if there is a goal product, only sound the horns if it is found
                if (this.ThingsToLookOutFor != null
                    && this.ThingsToLookOutFor.Length > 0
                    && this.GoalProductIsFound(fileFormattedProducts, this.ThingsToLookOutFor))
                {
                    return fileFormattedProducts;
                }
            }

            return string.Empty;
        }

        protected override void AssertAllFieldsAreValid()
        {
            if (this.NumberOfProductsOnTargetUrl <= 0)
            {
                throw new NullReferenceException("all fields must be set!");
            }

            base.AssertAllFieldsAreValid();
        }
    }
}
