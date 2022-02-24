using HtmlAgilityPack;
using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.IO;

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
            string emailSubject)
            : base(
                  targetUrl,
                  alarmMessageSubject,
                  emailSubject)
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

        protected abstract string FindProductsFromNodes(HtmlNodeCollection nodes);

        protected HtmlDocument LoadUrl()
        {
            var web = new HtmlWeb();
            try
            {
                return web.Load(TargetUrl);
            }
            catch (Exception e)
            {
                if (e is WebException || e is IOException)
                {
                    // Internet connection interrupted. Try again in five minutes.
                    Thread.Sleep(300000);
                    return this.LoadUrl();
                }

                throw;
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

        protected override void AssertAllFieldsAreValid()
        {
            if (this.TargetDivs == null)
            {
                throw new NullReferenceException("TargetDivs must be set!");
            }

            base.AssertAllFieldsAreValid();
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
