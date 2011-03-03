using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMail.Mails
{
    public interface IMail
    {
        string FromAddress { get; set; }
        ICollection<string> ToAddresses { get; set; }
        ICollection<string> CcAddresses { get; set; }
        ICollection<string> BccAddresses { get; set; }
        ICollection<string> Attachments { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        void Validate();
    }
}
