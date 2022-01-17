namespace DropCatcher.CustomDropCatchers.ListingBasedDropCatchers
{
    public class SafariZoneDropCatcher : ListingBasedDropCatcher
    {
        public SafariZoneDropCatcher(string[] thingsToLookOutFor = null)
            : base(
                  thingsToLookOutFor,
                  numberOfProductsOnTargetUrl: 4)
        {
            this.TargetUrl = "https://safari-zone.com/";
            this.DivClass = "//div[@class='product-card__name']  ";
            this.FileLogger = new FileLogger(path: "C:/Users/beabbaso/Documents/SafariZoneProductList.txt");
            this.AlarmSounder = new AlarmSounder(
                alarmSoundPath: "C:/Users/beabbaso/Documents/safariZoneDrop.wav",
                linkToProducts: this.TargetUrl,
                messageSubject: "New Safari Zone Drop!");
        }
    }
}
