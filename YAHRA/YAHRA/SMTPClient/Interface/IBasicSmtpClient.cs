using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHRA.SMTPClient.Interface
{
    public interface IBasicSmtpClient
    {
        void SendEmail(string to, string subject, string body);
    }
}
