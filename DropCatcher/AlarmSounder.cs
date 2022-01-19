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

        public static readonly SpeechSynthesizer Synthesizer = new();

        public AlarmSounder(
            string linkToProducts,
            string messageSubject)
        {
            this.linkToProducts = linkToProducts;
            this.messageSubject = messageSubject;
            this.smtpClient = CreateSmtpClient();
            Synthesizer.SetOutputToDefaultAudioDevice();
            Synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
        }

        public void SoundTheAlarm(string alarm)
        {
            Synthesizer.Speak(alarm);
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
