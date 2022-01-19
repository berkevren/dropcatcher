using DropCatcher.DataModel;
using Newtonsoft.Json;
using System.Net;

namespace DropCatcher.CustomDropCatchers.RequestDropCatchers
{
    public class AmiamiDropCatcher : DropCatcher
    {
        private const string AlarmMessageAmiami = "Ah me ah me Drop! Ah me ah me Drop! Ah me ah me Drop!";
        private const string EmailSubject = "Amiami Drop!";
        private const string FileLoggerPath = "C:/Users/berka/Documents/AmiamiProductList.txt";

        protected string RequestUrl { get; private set; }
        
        public AmiamiDropCatcher(
            AmiamiChaseProduct amiamiChaseProduct)
            : base(
                  amiamiChaseProduct.webUrl,
                  AlarmMessageAmiami,
                  EmailSubject,
                  FileLoggerPath)
        {
            this.RequestUrl = amiamiChaseProduct.requestUrl;
        }

        public override void CheckForProducts()
        {
            var request = WebRequest.Create(this.RequestUrl);
            request.ContentType = "application/json";
            request.Headers.Add("x-user-key", "amiami_dev");
            using System.IO.Stream stream = request.GetResponse().GetResponseStream();
            using System.IO.StreamReader streamReader = new System.IO.StreamReader(stream);
            var response = streamReader.ReadToEnd();
            var product = JsonConvert.DeserializeObject<AmiamiProduct>(response);
            if (product.IsInStock())
            {
                this.SoundTheHornsAndSendTheRavens(AlarmMessageAmiami + product.item.gname);
            }
        }
    }
}
