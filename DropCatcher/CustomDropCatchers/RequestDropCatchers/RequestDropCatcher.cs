using System.IO;
using System.Net;
using System.Threading;

namespace DropCatcher.CustomDropCatchers.RequestDropCatchers
{
    public abstract class RequestDropCatcher : DropCatcher
    {
        public RequestDropCatcher(
            string targetUrl,
            string customAlarmMessage,
            string emailSubject)
            : base(
                  targetUrl,
                  customAlarmMessage,
                  emailSubject)
        {
        }

        public override void CheckForProducts()
        {
            var request = this.CreateRequest();
            var response = this.GetProductJSON(request);
            var product = this.SerializeJSONReponse(response);
            if (IsProductInStock(product, out var productName))
            {
                this.SoundTheHornsAndSendTheRavens(productName);
            }
        }

        /// <summary>
        /// Sends a web requests and returns the json response.
        /// </summary>
        /// <returns>JSON resposne.</returns>
        protected string GetProductJSON(WebRequest request)
        {
            try
            {
                using Stream stream = request.GetResponse().GetResponseStream();
                using var streamReader = new StreamReader(stream);
                return streamReader.ReadToEnd();
            }
            catch (WebException)
            {
                // Internet connection interrupted. Try again in five minutes.
                Thread.Sleep(300000);
                return this.GetProductJSON(request);
            }
        }

        protected abstract WebRequest CreateRequest();
        protected abstract object SerializeJSONReponse(string response);
        protected abstract bool IsProductInStock(object product, out string productName);
    }
}
