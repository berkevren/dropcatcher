using System.Collections.Generic;

namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class GameNerdzDropCatcher : ListingBasedDropCatcher
    {
        public GameNerdzDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  targetDiv: "//h4[@class='card-title']  ",
                  thingsToLookOutFor: thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 20,
                  targetUrl: "https://www.gamenerdz.com/pokemon?sort=newest",
                  alarmMessage: "New Game Nerdz Drop!",
                  emailSubject: "New Game Nerdz Drop!",
                  fileLoggerPath: "C:/Users/beabbaso/Documents/GameNerdzProductList.txt")
        {
        }

        protected override string ToFileFormat(List<string> products)
        {
            var reformattedProducts = new List<string>();

            foreach (var product in products)
            {
                reformattedProducts.Add(
                    product.Replace("\n", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("&amp;", "&")
                    .Replace("&#x27;", "'")
                    .TrimStart()
                    .TrimEnd());
            }

            return base.ToFileFormat(reformattedProducts);
        }
    }
}
