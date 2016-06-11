using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CRM.Web.Utility
{
    
    public class EmailConfig : IEmailService
    {
        private readonly SmtpConfiguration _config;

        private const string UserNameKey = "UserName";
        private const string PasswordKey = "Password";
        private const string HostKey = "Host";
        private const string PortKey = "Port";
        private const string SslKey = "Ssl";

        public EmailConfig()
        {
            _config = new SmtpConfiguration();
            var UserName = ConfigurationManager.AppSettings[UserNameKey];
            var Password = ConfigurationManager.AppSettings[PasswordKey];
            var Host = ConfigurationManager.AppSettings[HostKey];
            var Port = Int32.Parse(ConfigurationManager.AppSettings[PortKey]);
            var Ssl = Boolean.Parse(ConfigurationManager.AppSettings[SslKey]);
            _config.Username = UserName;
            _config.Password = Password;
            _config.Host = Host;
            _config.Port = Port;
            _config.Ssl = Ssl;
        }

        public bool SendEmailMessage(EmailMessage message)
        {
            var success = false;
            try
            {
                var smtp = new SmtpClient
                {
                    Host = _config.Host,
                    Port = _config.Port,
                    EnableSsl = _config.Ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.Username, _config.Password)
                };

                using (var smtpMessage = new MailMessage(_config.Username, message.ToEmail))
                {
                    smtpMessage.Subject = message.Subject;
                    smtpMessage.Body = message.Body;
                    smtpMessage.IsBodyHtml = message.IsHtml;
                    smtp.Send(smtpMessage);
                }

                success = true;
            }
            catch (Exception ex)
            {
                //todo: add logging integration
                //throw;
            }

            return success;
        }
    }

    public interface IEmailService
    {
        bool SendEmailMessage(EmailMessage message);
    }
    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }
    public class SmtpConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }
}