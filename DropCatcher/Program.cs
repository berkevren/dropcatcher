using DropCatcher.CustomDropCatchers.RequestDropCatchers;
using DropCatcher.CustomDropCatchers.StockBasedDropCatchers;
using DropCatcher.DataModel;
using System.Threading;
using CustomDropCatcher = DropCatcher.CustomDropCatchers.DropCatcher;

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
            var dropCatchers = GetDropCatchers();
            
            while (true)
            {
                foreach (var dropCatcher in dropCatchers)
                {
                    dropCatcher.CheckForProducts();
                }

                WaitAWhile();
            }
        }

        public static CustomDropCatcher[] GetDropCatchers()
        {
            // var safariZoneDropCatcher = new SafariZoneDropCatcher(thingsToLookOutFor: new string[] { "Evolving", "evolving", "Chilling", "chilling", "marnie", "Marnie" });
            // var gameNerdzDropCatcher = new GameNerdzDropCatcher();
            return new CustomDropCatcher[]
            {
                new YuyuteiDropCatcher(
                    products: YuyuteiProduct.GetMarvelChaseProducts(),
                    targetDivs: new string[]
                    {
                        StringConstants.TargetDivs.YuyuteiMarvelMR,
                        StringConstants.TargetDivs.YuyuteiMarvelSR,
                    },
                    targetUrl: StringConstants.TargetUrls.YuyuteiMarvel),
                new YuyuteiDropCatcher(
                    products: YuyuteiProduct.GetMarvelChaseProducts(),
                    targetDivs: new string[]
                    {
                        StringConstants.TargetDivs.YuyuteiMarvelMR,
                        StringConstants.TargetDivs.YuyuteiMarvelSR,
                    },
                    targetUrl: StringConstants.TargetUrls.YuyuteiMarvelScratched),
                new YuyuteiDropCatcher(
                    products: YuyuteiProduct.GetKadokawaChaseProducts(),
                    targetDivs: new string[]
                    {
                        StringConstants.TargetDivs.YuyuteiKadokawaSP,
                        StringConstants.TargetDivs.YuyuteiKadokawaSBR,
                        StringConstants.TargetDivs.YuyuteiKadokawaRRR,
                        StringConstants.TargetDivs.YuyuteiKadokawaSR,
                    },
                    targetUrl: StringConstants.TargetUrls.YuyuteiKadokawa),
                new YuyuteiDropCatcher(
                    products: YuyuteiProduct.GetKadokawaChaseProducts(),
                    targetDivs: new string[]
                    {
                        StringConstants.TargetDivs.YuyuteiKadokawaSP,
                        StringConstants.TargetDivs.YuyuteiKadokawaSBR,
                        StringConstants.TargetDivs.YuyuteiKadokawaRRR,
                        StringConstants.TargetDivs.YuyuteiKadokawaSR,
                    },
                    targetUrl: StringConstants.TargetUrls.YuyuteiKadokawaScratched),
                new YuyuteiDropCatcher(
                    products: YuyuteiProduct.GetFujimiChaseProducts(),
                    targetDivs: new string[]
                    {
                        StringConstants.TargetDivs.YuyuteiFujimiFBR,
                        StringConstants.TargetDivs.YuyuteiFujimiRRR,
                        StringConstants.TargetDivs.YuyuteiFujimiSR,
                    },
                    targetUrl: StringConstants.TargetUrls.YuyuteiFujimi),
                new YuyuteiDropCatcher(
                    products: YuyuteiProduct.GetFujimiChaseProducts(),
                    targetDivs: new string[]
                    {
                        StringConstants.TargetDivs.YuyuteiFujimiFBR,
                        StringConstants.TargetDivs.YuyuteiFujimiRRR,
                        StringConstants.TargetDivs.YuyuteiFujimiSR,
                    },
                    targetUrl: StringConstants.TargetUrls.YuyuteiFujimiScratched),
                new AmiamiDropCatcher(AmiamiChaseProduct.WeissSchwarz.MarvelTrialDeck),
                new AmiamiDropCatcher(AmiamiChaseProduct.WeissSchwarz.HololiveBoosterBox),
                new AmiamiDropCatcher(AmiamiChaseProduct.WeissSchwarz.HololiveTrialDeck),
                new AmiamiDropCatcher(AmiamiChaseProduct.Pokemon.VMAXClimaxBoosterBox),
                new AmiamiDropCatcher(AmiamiChaseProduct.Pokemon.TwentyFifthAnniversaryBoosterBox),
            };
        }

        public static void WaitAWhile()
        {
            Thread.Sleep(TenMinutes);

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
