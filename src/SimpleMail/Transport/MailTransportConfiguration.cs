using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace SimpleMail.Transport
{
    public class MailTransportConfiguration
    {
        private const string PROPERTIES_FILE = "fluent-mail-api.properties";
        private const string KEY_SMTP_HOST = "smtp.server";
        private const string KEY_SMTP_PORT = "smtp.port";
        private const string KEY_AUTH_REQUIRED = "auth.required";
        private const string KEY_SMTP_USERNAME = "smtp.username";
        private const string KEY_SMTP_PASSWORD = "smtp.password";
        private const string KEY_SMTP_ENABLED_SSL = "use.secure.smtp";

        private string SmtpHost;
        private int SmtpPort;
        private bool AuthRequrired;
        private string SmtpUsername;
        private string SmtpPassword;
        private bool SmptEnabledSsl;

        public SmtpClient Smpt { get; set; }

        public MailTransportConfiguration()
        {
            LoadProperties();
            LoadSmtp();
        }

        private void LoadProperties()
        {            
            SetProperties(GetFileProperties());
        }

        private IDictionary<string, string> GetFileProperties()
        {
            if (!File.Exists(PROPERTIES_FILE))                
                throw new Exception(String.Format("Configuration file {0} not found.", PROPERTIES_FILE));

            IDictionary<string, string> properties = new Dictionary<string, string>();
            List<String> lines = new List<string>();
            using (StreamReader reader = new StreamReader(PROPERTIES_FILE, Encoding.GetEncoding("ISO-8859-1")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                if (lines.Count > 0)
                {
                    String[] keyValues = lines.ToArray();
                    properties = keyValues.ToDictionary(
                        s => (!String.IsNullOrEmpty(s) && s.Split('=').Length > 0) ? s.Split('=')[0].Trim() : String.Empty,
                        s => (!String.IsNullOrEmpty(s) && s.Split('=').Length > 1) ? s.Split('=')[1].Trim() : String.Empty);
                }

                reader.Close();
                reader.Dispose();
            }

            return properties;
        }

        private void SetProperties(IDictionary<string, string> properties)
        {            
            try
            {
                this.SmtpHost = properties[KEY_SMTP_HOST];
                this.SmtpPort = Convert.ToInt32(properties[KEY_SMTP_PORT]);
                this.AuthRequrired = Convert.ToBoolean(properties[KEY_AUTH_REQUIRED]);
                this.SmtpUsername = properties[KEY_SMTP_USERNAME];
                this.SmtpPassword = properties[KEY_SMTP_PASSWORD];
                this.SmptEnabledSsl = Convert.ToBoolean(properties[KEY_SMTP_ENABLED_SSL]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading the properties. Check the file properties.", ex.InnerException);
            }
        }

        private void LoadSmtp()
        {
            var smtpClient = new SmtpClient(this.SmtpHost, this.SmtpPort);
            smtpClient.EnableSsl = this.SmptEnabledSsl;            
            if (this.AuthRequrired)
                smtpClient.Credentials = new NetworkCredential(this.SmtpUsername, this.SmtpPassword);
            else
                smtpClient.UseDefaultCredentials = true;
            this.Smpt = smtpClient;
        }
    }
}
