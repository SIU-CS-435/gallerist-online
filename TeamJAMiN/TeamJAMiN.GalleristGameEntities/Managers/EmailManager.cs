using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities.Managers
{
    public class EmailManager
    {
        public static void SendEmail(string subject, string body, List<string> recipients)
        {
            //do email things
            var message = new MailMessage();
            message.Body = body;
            message.Subject = subject;
            foreach (var recipient in recipients)
            {
                message.To.Add(recipient);
            }
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Send(message);
            }
        }

        public static async Task SendEmailAsync(string subject, string body, List<string> recipients)
        {
            //do async email things
            var message = new MailMessage();
            message.Body = body;
            message.Subject = subject;
            foreach (var recipient in recipients)
            {
                message.To.Add(recipient);
            }
            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
