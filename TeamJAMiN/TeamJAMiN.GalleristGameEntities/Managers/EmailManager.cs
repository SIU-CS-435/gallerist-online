using System.Collections.Generic;
using System.Net.Mail;

namespace TeamJAMiN.GalleristComponentEntities.Managers
{
    public class EmailManager
    {
        public static void SendEmail(string title, string body, List<string> recipients)
        {
            //do email things
            var smtpClient = new SmtpClient();
            var message = new MailMessage();
            message.Body = body;
            message.Subject = title;
            foreach (var recipient in recipients)
            {
                message.To.Add(recipient);
            }
            smtpClient.Send(message);
        }
    }
}
