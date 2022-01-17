using HtmlAgilityPack;
using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace DropCatcher.CustomDropCatchers
{
    public class DropCatcher
    {
        public string TargetUrl { get; protected set; }
        
        public string DivClass { get; protected set; }

        public FileLogger FileLogger { get; protected set; }

        public AlarmSounder AlarmSounder { get; protected set; }

        public string[] ThingsToLookOutFor { get; protected set; }

        public DropCatcher(string[] thingsToLookOutFor)
        {
            this.ThingsToLookOutFor = thingsToLookOutFor;
        }

        // Gets nodes from the target url and returns them as a collection.
        protected HtmlNodeCollection GetNodesFromTargetUrl()
        {
            var web = new HtmlWeb();
            try
            {
                var doc = web.Load(TargetUrl);
                return doc.DocumentNode.SelectNodes(this.DivClass);
            }
            catch(WebException e)
            {
                // Internet connection interrupted. Try again in five minutes.
                Thread.Sleep(300000);
                return this.GetNodesFromTargetUrl();
            }
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

        protected void SoundTheHornsAndSendTheRavens(string products)
        {
            this.AlarmSounder.SoundTheAlarm();
            this.AlarmSounder.SendEmail(products);
        }

        protected virtual void AssertAllFieldsAreValid()
        {
            if (this.TargetUrl == null
                || this.DivClass == null
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
