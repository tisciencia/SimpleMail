using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleMail.Validation;

namespace SimpleMail.Mails
{
    public class FluentMail : IMailBuilder
    {
        private IMail _Mail;
        public IMailBuilder From(string address)
        {
            this._Mail.FromAddress = address;
            return this;
        }
        public IMailBuilder To(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
                this._Mail.ToAddresses.Add(addresses[i]);

            return this;
        }
        public IMailBuilder Cc(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
                this._Mail.CcAddresses.Add(addresses[i]);

            return this;
        }
        public IMailBuilder Bcc(params string[] addresses)
        {
            for (int i = 0; i < addresses.Length; i++)
                this._Mail.BccAddresses.Add(addresses[i]);

            return this;
        }
        public IMailBuilder WithSubject(string subject)
        {
            this._Mail.Subject = subject;
            return this;
        }
        public IMailBuilder WithBody(string body)
        {
            this._Mail.Body = body;
            return this;
        }
        public IMailBuilder WithAttachment(params string[] attachments)
        {
            for (int i = 0; i < attachments.Length; i++)
            {
                this._Mail.Attachments.Add(attachments[i]);
            }
            return this;
        }

        public IMail Builder()
        {
            _Mail.Validate();
            return _Mail;
        }

        public FluentMail()
        {
            _Mail = new Mail();
        }
    }
}
