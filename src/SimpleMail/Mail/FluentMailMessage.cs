using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMail.Mail
{
    public class FluentMailMessage : IMailBuilder
    {
        public IMail Mail { get; set; }
        
        public IMailBuilder From(string address)
        {
            this.Mail.FromAddress = address;
            return this;
        }
        public IMailBuilder To(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
            {
                this.Mail.ToAddresses.Add(addresses[i]);
            }
            return this;
        }
        public IMailBuilder Cc(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
            {
                this.Mail.CcAddresses.Add(addresses[i]);
            }
            return this;
        }
        public IMailBuilder Bcc(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
            {
                this.Mail.BccAddresses.Add(addresses[i]);
            }
            return this;
        }
        public IMailBuilder WithSubject(string subject)
        {
            this.Mail.Subject = subject;
            return this;
        }
        public IMailBuilder WithBody(string body)
        {
            this.Mail.Body = body;
            return this;
        }
        public IMailBuilder WithAttachment(params string[] attachments)
        {
            for (int i = 0; i < attachments.Length; i++)
            {
                this.Mail.Attachments.Add(attachments[i]);
            }
            return this;
        }

        public FluentMailMessage()
        {
            Mail = new MailMessage();
        }
    }
}
