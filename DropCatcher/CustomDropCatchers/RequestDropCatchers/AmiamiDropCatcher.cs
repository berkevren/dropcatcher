using DropCatcher.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            var uri = new Uri(this.RequestUrl);
            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Headers.Add("x-user-key", "amiami_dev");
            using System.IO.Stream s = request.GetResponse().GetResponseStream();
            using System.IO.StreamReader sr = new System.IO.StreamReader(s);
            var jsonResponse = sr.ReadToEnd();
            var product = JsonConvert.DeserializeObject<AmiamiProduct>(jsonResponse);
            if (product.IsInStock())
            {
                this.SoundTheHornsAndSendTheRavens(AlarmMessageAmiami + product.item.gname);
            }
        }
    }
}
