using DropCatcher.DataModel;
using Newtonsoft.Json;
using System.Net;

namespace DropCatcher.CustomDropCatchers.RequestDropCatchers
{
    public class AmiamiDropCatcher : RequestDropCatcher
    {
        private const string AlarmMessageAmiami = "Ah me ah me Drop! Ah me ah me Drop! Ah me ah me Drop!";
        private const string EmailSubject = "Amiami Drop!";

        protected string RequestUrl { get; private set; }
        
        public AmiamiDropCatcher(AmiamiChaseProduct amiamiChaseProduct)
            : base(
                  amiamiChaseProduct.webUrl,
                  AlarmMessageAmiami,
                  EmailSubject)
        {
            this.RequestUrl = amiamiChaseProduct.requestUrl;
        }

        protected override WebRequest CreateRequest()
        {
            var request = WebRequest.Create(this.RequestUrl);
            request.ContentType = "application/json";
            request.Headers.Add("x-user-key", "amiami_dev");

            return request;
        }

        protected override AmiamiProduct SerializeJSONReponse(string response)
        {
            return JsonConvert.DeserializeObject<AmiamiProduct>(response);
        }

        protected override bool IsProductInStock(object product, out string productName)
        {
            if (product is AmiamiProduct amiamiProduct)
            {
                productName = amiamiProduct.item.gname;
                return amiamiProduct.IsInStock();
            }

            productName = string.Empty;
            return false;
        }
    }
}
