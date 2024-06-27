using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.Email
{
    public interface IEmailSender
    {
        public void Send(SendEmailDTO obj);

    }

    public class SendEmailDTO
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
