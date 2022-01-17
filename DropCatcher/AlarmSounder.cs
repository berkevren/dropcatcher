using System;
using System.Media;
using System.Net;
using System.Net.Mail;

namespace DropCatcher
{
    public class AlarmSounder
    {
        private readonly string alarmSoundPath;
        private readonly string linkToProducts;
        private readonly string messageSubject;
        private readonly SmtpClient smtpClient;

        public AlarmSounder(
            string alarmSoundPath,
            string linkToProducts,
            string messageSubject)
        {
            this.alarmSoundPath = alarmSoundPath;
            this.linkToProducts = linkToProducts;
            this.messageSubject = messageSubject;
            this.smtpClient = CreateSmtpClient();
        }

        public void SoundTheAlarm()
        {
            var alarmSound = new SoundPlayer(this.alarmSoundPath);
            alarmSound.Play();
        }

        public void SendEmail(string products)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("berkzeguet@hotmail.com");
            message.Subject = this.messageSubject;
            message.Body = String.Concat(this.linkToProducts, "\n", products);
            message.To.Add("berkabbasoglu@hotmail.com");
            message.To.Add("cemekmekcioglu@icloud.com");

            this.smtpClient.Send(message);
        }

        private static SmtpClient CreateSmtpClient()
        {
            return new SmtpClient("smtp.live.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("berkzeguet@hotmail.com", "=,E':'_w*VWKg8B"),
                EnableSsl = true,
            };
        }
    }
}
