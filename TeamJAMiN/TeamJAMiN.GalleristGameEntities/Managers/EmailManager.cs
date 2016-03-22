using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities.Managers
{
    public class EmailManager
    {
        public static void SendEmail(string body, string title, List<string> recipients)
        {
            var smtpClient = new SmtpClient();
            var message = new MailMessage();
            message.Body = body;
            message.Subject = title;
            foreach (var recipient in recipients)
            {
                message.To.Add(recipient);
            }
            smtpClient.Send(message);
            //do email things
        }
    }
}
