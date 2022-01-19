using System.Collections.Generic;

namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class TargetHiddenFatesDropCatcher : ListingBasedDropCatcher
    {
        public TargetHiddenFatesDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  targetDiv: "//div[@class='Col-favj32-0 hKWLcP']  ",
                  thingsToLookOutFor: thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 1,
                  targetUrl: "https://www.gamenerdz.com/pokemon?sort=newest",
                  alarmMessage: "New Game Nerdz Drop!",
                  emailSubject: "New Game Nerdz Drop!",
                  fileLoggerPath: "C:/Users/beabbaso/Documents/GameNerdzProductList.txt")
        {
        }
    }
}
