using DropCatcher.DataModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DropCatcher.CustomDropCatchers.RequestDropCatchers
{
    public class TCGPlayerDropCatcher : RequestDropCatcher
    {
        private const string AlarmMessageTCG = "TCG Player drop! TCG Player drop! TCG Player drop!";
        private const string EmailSubject = "TCGPlayer Drop!";
        private List<string> FoundProductNames;
        private TCGPlayerChaseProduct TCGPlayerChaseProduct;

        public TCGPlayerDropCatcher(TCGPlayerChaseProduct tcgPlayerChaseProduct)
            : base(
                  tcgPlayerChaseProduct.webUrl,
                  AlarmMessageTCG,
                  EmailSubject,
                  tcgPlayerChaseProduct.requestUrl)
        {
            FoundProductNames = new();
            TCGPlayerChaseProduct = tcgPlayerChaseProduct;
        }

        protected override WebRequest CreateRequest()
        {
            var request = WebRequest.Create(this.RequestUrl);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Add("Cookie", "TCG_VisitorKey=84c74136-46fb-411f-968f-c9fdd0de824e");

            var data = Encoding.ASCII.GetBytes(@"{""filters"":{""term"":{""sellerStatus"":""Live"",""channelId"":0},""range"":{""quantity"":{""gte"":1}},""exclude"":{""channelExclusion"":0}},""context"":{""shippingCountry"":""US"",""cart"":{}},""aggregations"":[""listingType""],""size"":0}");
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            return request;
        }

        protected override bool IsProductInStock(object product, out string productName)
        {
            if (product is TCGPlayerProduct tcgPlayerProduct)
            {
                productName = this.TCGPlayerChaseProduct.title;
                if (tcgPlayerProduct.IsInStock()
                    && !this.FoundProductNames.Contains(productName))
                {
                    this.FoundProductNames.Add(productName);
                    return true;
                }
            }

            productName = string.Empty;
            return false;
        }

        protected override object SerializeJSONReponse(string response)
        {
            return JsonConvert.DeserializeObject<TCGPlayerProduct>(response);
        }
    }
}
