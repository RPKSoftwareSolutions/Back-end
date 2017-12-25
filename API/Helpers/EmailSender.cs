using AuthServer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class EmailSender
    {
        private readonly IUnitOfWork _unitOfWork;
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SenderEmail { get; set; }

        public EmailSender(IUnitOfWork unitOfWork)
        {
            // doing something to read this initial variabkles from appsettings.json would be more desirable;
            // however I was not able to get the dependency injection working properly.

            this._unitOfWork = unitOfWork;

            var smtpSettings = _unitOfWork.Settings.GetSmtpSettings();

            Server = smtpSettings.Server;
            Port = smtpSettings.Port;
            Username = smtpSettings.Username;
            Password = smtpSettings.Password;
            SenderEmail = smtpSettings.SenderAddress;
        }

        public void SendEmail(string To, string Subject, string Body)
        {
            var m = new MailMessage
            {
                From = new MailAddress(SenderEmail)
            };
            m.To.Add(To);
            m.Body = Body;
            m.Subject = Subject;

            SmtpClient client = new SmtpClient(this.Server, this.Port);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(this.Username, this.Password);
            client.Send(m);
        }
    }
}
