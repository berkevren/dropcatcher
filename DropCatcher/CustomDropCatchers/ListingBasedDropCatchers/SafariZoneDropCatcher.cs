namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class SafariZoneDropCatcher : ListingBasedDropCatcher
    {
        public SafariZoneDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 4,
                  targetDiv: "//div[@class='product-card__name']  ",
                  alarmMessage: "New Safari Zone Drop!")
        {
            this.TargetUrl = "https://safari-zone.com/";
            this.FileLogger = new FileLogger(path: "C:/Users/beabbaso/Documents/SafariZoneProductList.txt");
            this.AlarmSounder = new AlarmSounder(
                linkToProducts: this.TargetUrl,
                messageSubject: "New Safari Zone Drop!");
        }
    }
}
