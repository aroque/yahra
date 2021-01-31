using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YAHRA.SMTPClient.Interface;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace YAHRA.SMTPClient
{
    public class BasicSmtpClient : IBasicSmtpClient
    {
        private SmtpClient _smtpClient;

        public BasicSmtpClient()
        {
            _smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtp_server"], Int32.Parse(ConfigurationManager.AppSettings["smtp_port"]))
            {
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["smtp_username"], ConfigurationManager.AppSettings["smtp_password"]),
                EnableSsl = bool.Parse(ConfigurationManager.AppSettings["smtp_enableSsl"])
            };
        }

        public void SendEmail(string to, string subject, string body)
        {
            _smtpClient.Send(ConfigurationManager.AppSettings["smtp_from"], to, subject, body);
        }
    }
}