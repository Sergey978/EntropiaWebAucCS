using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace EntropiaWebAuc.Services
{
    public class MailSender
    {
        public async Task<string> SendMail(string recipient, string subject, string message)
        {
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true; // comment if local test to directory

            try
            {
                var mail = new MailMessage();
                mail.To.Add(new MailAddress(recipient));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
               await  client.SendMailAsync(mail);
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
    }
}