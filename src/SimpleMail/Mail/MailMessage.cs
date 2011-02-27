using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMail.Mail
{
    public class MailMessage : IMail
    {
        public string FromAddress { get; set; }
        public ICollection<string> ToAddresses { get; set; }
        public ICollection<string> CcAddresses { get; set; }
        public ICollection<string> BccAddresses { get; set; }
        public ICollection<string> Attachments { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailMessage()
        {
            ToAddresses = new HashSet<string>();
            CcAddresses = new HashSet<string>();
            BccAddresses = new HashSet<string>();
            Attachments = new HashSet<string>();
        }
    }
}
