using AspAZ.Application.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDTO obj)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("acacarbre@gmail.com", "olmtifgkxwbbjtvg")
            };

            var message = new MailMessage("acacarbre@gmail.com", obj.SendTo);
            message.Subject = obj.Subject;
            message.Body = obj.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
