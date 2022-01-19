using HtmlAgilityPack;
using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace DropCatcher.CustomDropCatchers
{
    public abstract class HTMLDropCatcher : DropCatcher
    {
        
        public string[] TargetDivs { get; protected set; }

        public string[] ThingsToLookOutFor { get; protected set; }

        public HTMLDropCatcher(
            string[] targetDivs,
            string[] thingsToLookOutFor,
            string targetUrl,
            string alarmMessageSubject,
            string emailSubject,
            string fileLoggerPath)
            : base(
                  targetUrl,
                  alarmMessageSubject,
                  emailSubject,
                  fileLoggerPath)
        {
            this.TargetDivs = targetDivs;
            this.ThingsToLookOutFor = thingsToLookOutFor;
        }

        public override void CheckForProducts()
        {
            this.AssertAllFieldsAreValid();

            var doc = this.LoadUrl();
            var stringBuidler = new StringBuilder();

            foreach (var divClass in TargetDivs)
            {
                var nodes = this.GetNodesFromLoadedDoc(doc, divClass);

                if (nodes == null)
                {
                    break;
                }

                stringBuidler.Append(FindProductsFromNodes(nodes));
            }

            var allProducts = stringBuidler.ToString();
            if (allProducts != null
                && !allProducts.Equals(string.Empty))
            {
                this.SoundTheHornsAndSendTheRavens(allProducts);
            }
        }

        protected abstract string FindProductsFromNodes(HtmlAgilityPack.HtmlNodeCollection nodes);

        protected HtmlDocument LoadUrl()
        {
            var web = new HtmlWeb();
            try
            {
                return web.Load(TargetUrl);
            }
            catch (WebException e)
            {
                // Internet connection interrupted. Try again in five minutes.
                Thread.Sleep(300000);
                return this.LoadUrl();
            }
        }

        // Gets nodes from the target url and returns them as a collection.
        protected HtmlNodeCollection GetNodesFromLoadedDoc(HtmlDocument doc, string divClass)
        {
            return doc.DocumentNode.SelectNodes(divClass);
        }

        // Converts the list of nodes parsed from html to a file-ready string.
        protected virtual string ToFileFormat(List<string> products)
        {
            var stringBuilder = new StringBuilder(DateTime.Now.ToString());
            stringBuilder.Append("\n");

            foreach (var product in products)
            {
                stringBuilder.Append(product);
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }

        protected virtual void AssertAllFieldsAreValid()
        {
            if (this.TargetUrl == null
                || this.TargetDivs == null
                || this.FileLogger == null
                || this.AlarmSounder == null)
            {
                throw new NullReferenceException("all fields must be set!");
            }
        }

        protected bool GoalProductIsFound(string products, string[] goalProducts)
        {
            if (goalProducts != null
                && goalProducts.Length < 1)
            {
                return false;
            }

            foreach(var goalProduct in goalProducts)
            {
                if (products.Contains(goalProduct))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
