using System.Collections.Generic;

namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class TargetHiddenFatesDropCatcher : ListingBasedDropCatcher
    {
        public TargetHiddenFatesDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 1,
                  targetDiv: "//div[@class='Col-favj32-0 hKWLcP']  ",
                  alarmMessage: "New Game Nerdz Drop!")
        {
            this.TargetUrl = "https://www.gamenerdz.com/pokemon?sort=newest";
            this.NumberOfProductsOnTargetUrl = 1;
            this.FileLogger = new FileLogger(path: "C:/Users/beabbaso/Documents/GameNerdzProductList.txt");
            this.AlarmSounder = new AlarmSounder(
                linkToProducts: this.TargetUrl,
                messageSubject: "New Game Nerdz Drop!");
        }
    }
}
