using DropCatcher.DataModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace DropCatcher.CustomDropCatchers.RequestDropCatchers
{
    public class AmiamiDropCatcher : RequestDropCatcher
    {
        private const string AlarmMessageAmiami = "Ah me ah me Drop! Ah me ah me Drop! Ah me ah me Drop!";
        private const string EmailSubject = "Amiami Drop!";
        private List<string> foundProductNames;
        
        public AmiamiDropCatcher(AmiamiChaseProduct amiamiChaseProduct)
            : base(
                  amiamiChaseProduct.webUrl,
                  AlarmMessageAmiami,
                  EmailSubject,
                  amiamiChaseProduct.requestUrl)
        {
            this.foundProductNames = new();
        }

        protected override WebRequest CreateRequest()
        {
            var request = WebRequest.Create(this.RequestUrl);
            request.ContentType = "application/json";
            request.Headers.Add("x-user-key", "amiami_dev");

            return request;
        }

        protected override bool IsProductInStock(object product, out string productName)
        {
            if (product is AmiamiProduct amiamiProduct)
            {
                productName = amiamiProduct.item.gname;
                if (amiamiProduct.IsInStock()
                    && !this.foundProductNames.Contains(productName))
                {
                    this.foundProductNames.Add(productName);
                    return true;
                }
            }

            productName = string.Empty;
            return false;
        }

        protected override AmiamiProduct SerializeJSONReponse(string response)
        {
            return JsonConvert.DeserializeObject<AmiamiProduct>(response);
        }
    }
}
