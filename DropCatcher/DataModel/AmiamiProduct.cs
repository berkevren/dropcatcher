﻿namespace DropCatcher.DataModel
{
    public class AmiamiProduct
    {
        public Item item { get; set; }

        public class Item
        {
            public string gname { get; set; }
            public int cart_type { get; set; }
        }

        public bool IsInStock()
        {
            return this.item.cart_type.Equals(7)  // back-order
                || this.item.cart_type.Equals(8)  // pre-order
                || this.item.cart_type.Equals(9); // order
        }
    }

    public class AmiamiChaseProduct
    {
        public string webUrl;
        public string requestUrl;

        public class WeissSchwarz
        {
            public readonly static AmiamiChaseProduct MarvelTrialDeck = new()
            {
                webUrl = "https://www.amiami.com/eng/detail/?scode=CARD-00015766",
                requestUrl = "https://api.amiami.com/api/v1.0/item?gcode=CARD-00015766&lang=eng&mcode=7001687591&ransu=vTvY43w9rrKK0EMkXxuFduO2d1SJmk30",
            };

            public readonly static AmiamiChaseProduct HololiveTrialDeck = new()
            {
                webUrl = "https://www.amiami.com/eng/detail/?gcode=CARD-00014799",
                requestUrl = "https://api.amiami.com/api/v1.0/item?gcode=CARD-00014799&lang=eng&mcode=7001687591&ransu=mFWqyaFUV5NzXcWXp4bV8xbZggJyxY86",
            };

            public readonly static AmiamiChaseProduct HololiveBoosterBox = new()
            {
                webUrl = "https://www.amiami.com/eng/detail/?gcode=CARD-00014812",
                requestUrl = "https://api.amiami.com/api/v1.0/item?gcode=CARD-00014812&lang=eng&mcode=7001687591&ransu=mFWqyaFUV5NzXcWXp4bV8xbZggJyxY86",
            };
        }

        public class Pokemon
        {
            public readonly static AmiamiChaseProduct VMAXClimaxBoosterBox = new()
            {
                webUrl = "https://www.amiami.com/eng/detail/?gcode=CARD-00015536",
                requestUrl = "https://api.amiami.com/api/v1.0/item?gcode=CARD-00015536&lang=eng&ransu=vTvY43w9rrKK0EMkXxuFduO2d1SJmk30",
            };

            public readonly static AmiamiChaseProduct TwentyFifthAnniversaryBoosterBox = new()
            {
                webUrl = "https://www.amiami.com/eng/detail/?scode=CARD-00015049",
                requestUrl = "https://api.amiami.com/api/v1.0/item?scode=CARD-00015049&lang=eng&mcode=7001687591&ransu=mFWqyaFUV5NzXcWXp4bV8xbZggJyxY86",
            };
        }
    }
}
