using System;

namespace DropCatcher.CustomDropCatchers
{
    public abstract class DropCatcher
    {
        public string TargetUrl { get; protected set; }

        public string AlarmMessage { get; protected set; }

        public AlarmSounder AlarmSounder { get; protected set; }

        public DropCatcher(
            string targetUrl,
            string customAlarmMessage,
            string emailSubject)
        {
            this.TargetUrl = targetUrl;
            this.AlarmMessage = customAlarmMessage;
            this.AlarmSounder = new AlarmSounder(
                linkToProducts: this.TargetUrl,
                messageSubject: emailSubject);
        }

        public abstract void CheckForProducts();

        protected virtual void AssertAllFieldsAreValid()
        {
            if (this.TargetUrl == null
                || this.AlarmSounder == null)
            {
                throw new NullReferenceException("all fields must be set!");
            }
        }

        protected void SoundTheHornsAndSendTheRavens(string products)
        {
            this.AlarmSounder.SoundTheAlarm(this.AlarmMessage + products);
            this.AlarmSounder.SendEmail(products);
        }
    }
}
