using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropCatcher.CustomDropCatchers
{
    public abstract class DropCatcher
    {
        public string TargetUrl { get; protected set; }

        public string AlarmMessage { get; protected set; }

        public AlarmSounder AlarmSounder { get; protected set; }

        public FileLogger FileLogger { get; protected set; }

        public DropCatcher(
            string targetUrl,
            string customAlarmMessage,
            string emailSubject,
            string fileLoggerPath)
        {
            this.TargetUrl = targetUrl;
            this.AlarmMessage = customAlarmMessage;
            this.AlarmSounder = new AlarmSounder(
                linkToProducts: this.TargetUrl,
                messageSubject: emailSubject);
            this.FileLogger = new FileLogger(path: fileLoggerPath);
        }
        public abstract void CheckForProducts();

        protected void SoundTheHornsAndSendTheRavens(string products)
        {
            this.AlarmSounder.SoundTheAlarm(products);
            this.AlarmSounder.SendEmail(products);
        }
    }
}
