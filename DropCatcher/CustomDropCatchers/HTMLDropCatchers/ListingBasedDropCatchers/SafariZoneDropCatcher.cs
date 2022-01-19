namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class SafariZoneDropCatcher : ListingBasedDropCatcher
    {
        public SafariZoneDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  targetDiv: "//div[@class='product-card__name']  ",
                  thingsToLookOutFor: thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 4,
                  targetUrl: "https://safari-zone.com/",
                  alarmMessage: "New Safari Zone Drop!",
                  emailSubject: "New Safari Zone Drop!",
                  fileLoggerPath: "C:/Users/beabbaso/Documents/SafariZoneProductList.txt")
        {
        }
    }
}
