using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleMail.Validation;

namespace SimpleMail.Mails
{
    public class Mail : IMail
    {
        public string FromAddress { get; set; }
        public ICollection<string> ToAddresses { get; set; }
        public ICollection<string> CcAddresses { get; set; }
        public ICollection<string> BccAddresses { get; set; }
        public ICollection<string> Attachments { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Mail()
        {
            ToAddresses = new HashSet<string>();
            CcAddresses = new HashSet<string>();
            BccAddresses = new HashSet<string>();
            Attachments = new HashSet<string>();
        }

        public void Validate()
        {
            ValidateRequiredInfo();
            ValidateAddresses();
        }

        private void ValidateRequiredInfo()
        {
            if (FromAddress == null)
                throw new ArgumentNullException("From address cannot be null");

            if (ToAddresses.Count == 0)
                throw new ArgumentException("Email should have at least one to address");

            if (Subject == null)
                throw new ArgumentNullException("Subject cannot be null");

            if (Body == null)
                throw new ArgumentNullException("Body cannot be null");
        }

        private void ValidateAddresses()
        {
            if (!MailAddressValidator.validate(FromAddress))
                throw new ArgumentException("From: " + FromAddress);

            foreach (var email in ToAddresses)
                if (!MailAddressValidator.validate(email))
                    throw new ArgumentException("To: " + email);

            foreach (var email in CcAddresses)
                if (!MailAddressValidator.validate(email))
                    throw new ArgumentException("Cc: " + email);

            foreach (var email in BccAddresses)
                if (!MailAddressValidator.validate(email))
                    throw new ArgumentException("Bcc: " + email);            
        }
    }
}
