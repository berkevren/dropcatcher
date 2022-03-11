using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DropCatcher.DataModel
{
    public class TCGPlayerProduct
    {
        public List<Results> results { get; set; }

        public class Results
        {
            public int totalResults { get; set; }
        }

        public bool IsInStock()
        {
            return this.results[0].totalResults > 0;
        }
    }

    public class TCGPlayerChaseProduct
    {
        public string webUrl;
        public string requestUrl;
        public string title;

        public class WeissSchwarz
        {
            public readonly static TCGPlayerChaseProduct RoxyTDSP = new()
            {
                webUrl = "https://www.tcgplayer.com/product/265238/weiss-schwarz-mushoku-tensei-jobless-reincarnation-loli-scornful-eyes-unfriendly-roxy-sp?xid=pid080de96-25c5-4058-90f1-d8ecb715d169&page=1&Language=English",
                requestUrl = "https://mpapi.tcgplayer.com/v2/product/265238/listings",
                title = "Roxy TD SP Jobless Reincarnation",
            };

            public readonly static TCGPlayerChaseProduct KurumiStampedPromo = new()
            {
                webUrl = "https://www.tcgplayer.com/product/234761/weiss-schwarz-bushiroad-event-cards-kurumi-tokisaki-spring-fest-2021?xid=pi88b689b5-13d8-4063-a224-4534f81e26f2&page=1&Language=English",
                requestUrl = "https://mpapi.tcgplayer.com/v2/product/234761/listings",
                title = "Kurumi Congratulations Stamped Promo",
            };
        }
    }
}
