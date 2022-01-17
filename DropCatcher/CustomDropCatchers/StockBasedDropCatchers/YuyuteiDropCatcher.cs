using System;
using System.Collections.Generic;
using System.Text;

namespace DropCatcher.CustomDropCatchers.StockBasedDropCatchers
{
    public class YuyuteiDropCatcher : StockBasedDropCatcher
    {
        public YuyuteiDropCatcher(
            string targetDiv,
            string targetUrl,
            string[] thingsToLookOutFor,
            string[] explanations = null)
            : base(
                  thingsToLookOutFor,
                  explanations)
        {
            this.TargetUrl = targetUrl;
            this.DivClass = targetDiv;
            this.FileLogger = new FileLogger(path: "C:/Users/berka/Documents/YuyuteiProductList.txt");
            this.AlarmSounder = new AlarmSounder(
                alarmSoundPath: "C:/Users/berka/Documents/yuyuteidrop.wav",
                linkToProducts: this.TargetUrl,
                messageSubject: "New Yuyutei Drop!");
        }
    }
}
