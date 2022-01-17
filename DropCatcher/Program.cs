using DropCatcher.CustomDropCatchers;
using DropCatcher.CustomDropCatchers.StockBasedDropCatchers;
using System;
using System.Threading;

namespace DropCatcher
{
    public class Program
    {
        const int OneMinute = 60000;
        const int TwoMinutes = 120000;
        const int FiveMinutes = 300000;
        const int TenMinutes = 600000;

        public static void Main()
        {
            // var safariZoneDropCatcher = new SafariZoneDropCatcher(thingsToLookOutFor: new string[] { "Evolving", "evolving", "Chilling", "chilling", "marnie", "Marnie" });
            // var gameNerdzDropCatcher = new GameNerdzDropCatcher();
            var yuyuteiDropCatcherMarvel = new YuyuteiDropCatcher(
                thingsToLookOutFor: new string[] { "MAR/S89-031MR", "MAR/S89-033MR", "MAR/S89-035MR", "MAR/S89-038MR", "MAR/S89-042MR", "MAR/S89-077MR" },
                explanations: new string[] { "Spiderman MR", "Captain Marvel MR", "Black Panther MR", "Dr Strange MR", "Black Widow MR", "Scarlet Witch MR" },
                targetDiv: "//li[@class='card_unit rarity_MR']  ",
                targetUrl: "https://yuyu-tei.jp/game_ws/sell/sell_price.php?ver=mar&menu=newest");

            var yuyuteiDropCatcherMio = new YuyuteiDropCatcher(
                thingsToLookOutFor: new string[] { "Sst/W62-051SP" },
                explanations: new string[] { "Mio SP" },
                targetDiv: "//li[@class='card_unit rarity_SP']  ",
                targetUrl: "https://yuyu-tei.jp/game_ws/sell/sell_price.php?name=&vers%5B%5D=kadokawas&rare=&type=&kizu=0");

            while (true)
            {
                yuyuteiDropCatcherMarvel.CheckForProducts();
                yuyuteiDropCatcherMio.CheckForProducts();
                WaitAWhile();
            }
        }

        public static void WaitAWhile()
        {
            Thread.Sleep(FiveMinutes);

            /*
            if (DateTime.Now.Hour < 9
                    || DateTime.Now.Hour > 19)
            {
                Thread.Sleep(TenMinutes);
            }
            else
            {
                Thread.Sleep(TwoMinutes);
            }
            */
        }
    }
}
