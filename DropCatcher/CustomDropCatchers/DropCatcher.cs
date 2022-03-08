using System;

namespace DropCatcher.CustomDropCatchers
{
    public abstract class DropCatcher
    {
        public string TargetUrl { get; protected set; }

        public string AlarmMessage { get; protected set; }

        public string emailSubject { get; protected set; }

        public DropCatcher(
            string targetUrl,
            string customAlarmMessage,
            string emailSubject)
        {
            this.TargetUrl = targetUrl;
            this.AlarmMessage = customAlarmMessage;
            this.emailSubject = emailSubject;
        }

        public abstract void CheckForProducts();

        protected virtual void AssertAllFieldsAreValid()
        {
            if (this.TargetUrl == null)
            {
                throw new NullReferenceException("all fields must be set!");
            }
        }

        protected void SoundTheHornsAndSendTheRavens(string products)
        {
            var alarmSounder = new AlarmSounder(
                linkToProducts: this.TargetUrl,
                messageSubject: emailSubject);
            alarmSounder.SoundTheAlarm(this.AlarmMessage + products);
            alarmSounder.SendEmail(products);
        }
    }
}
