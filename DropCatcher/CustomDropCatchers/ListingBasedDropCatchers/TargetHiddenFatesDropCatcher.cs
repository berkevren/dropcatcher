using System.Collections.Generic;

namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class TargetHiddenFatesDropCatcher : ListingBasedDropCatcher
    {
        public TargetHiddenFatesDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 1)
        {
            this.TargetUrl = "https://www.gamenerdz.com/pokemon?sort=newest";
            this.DivClass = "//div[@class='Col-favj32-0 hKWLcP']  ";
            this.NumberOfProductsOnTargetUrl = 1;
            this.FileLogger = new FileLogger(path: "C:/Users/beabbaso/Documents/GameNerdzProductList.txt");
            this.AlarmSounder = new AlarmSounder(
                alarmSoundPath: "C:/Users/beabbaso/Documents/gameNerdzDrop.wav",
                linkToProducts: this.TargetUrl,
                messageSubject: "New Game Nerdz Drop!");
        }
    }
}
