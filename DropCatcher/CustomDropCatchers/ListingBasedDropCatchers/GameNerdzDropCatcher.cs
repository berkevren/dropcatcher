using System.Collections.Generic;

namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class GameNerdzDropCatcher : ListingBasedDropCatcher
    {
        public GameNerdzDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 20)
        {
            this.TargetUrl = "https://www.gamenerdz.com/pokemon?sort=newest";
            this.DivClass = "//h4[@class='card-title']  ";
            this.FileLogger = new FileLogger(path: "C:/Users/beabbaso/Documents/GameNerdzProductList.txt");
            this.AlarmSounder = new AlarmSounder(
                alarmSoundPath: "C:/Users/beabbaso/Documents/gameNerdzDrop.wav",
                linkToProducts: this.TargetUrl,
                messageSubject: "New Game Nerdz Drop!");
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
