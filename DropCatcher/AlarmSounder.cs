using System;
using System.Net;
using System.Net.Mail;
using System.Speech.Synthesis;

namespace DropCatcher
{
    public class AlarmSounder
    {
        private readonly string linkToProducts;
        private readonly string messageSubject;
        private readonly SmtpClient smtpClient;
        private readonly SpeechSynthesizer synthesizer;

        public AlarmSounder(
            string linkToProducts,
            string messageSubject)
        {
            this.linkToProducts = linkToProducts;
            this.messageSubject = messageSubject;
            this.smtpClient = CreateSmtpClient();
            this.synthesizer = new();
            this.synthesizer.SetOutputToDefaultAudioDevice();
            this.synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
        }

        public void SoundTheAlarm(string alarm)
        {
            this.synthesizer.Speak(alarm);
        }

        public void SendEmail(string products)
        {
            var message = new MailMessage
            {
                From = new MailAddress(StringConstants.EmailAddresses.Berkzeguet),
                Subject = this.messageSubject,
                Body = String.Concat(this.linkToProducts, "\n", products)
            };
            message.To.Add(StringConstants.EmailAddresses.BerkAbbasoglu);
            message.To.Add(StringConstants.EmailAddresses.CemEkm);

            this.smtpClient.Send(message);
        }

        private static SmtpClient CreateSmtpClient()
        {
            return new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential
                {
                    UserName = StringConstants.EmailAddresses.Berkzeguet,
                    Password = StringConstants.EmailAddresses.BerkzeguetPassword,
                },
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };
        }
    }
}
