using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMail.Mail
{
    public interface IMailBuilder
    {
        IMail Mail { get; set; }
        IMailBuilder From(string address);
        IMailBuilder To(params string[] addresses);
        IMailBuilder Cc(params string[] addresses);
        IMailBuilder Bcc(params string[] addresses);
        IMailBuilder WithSubject(string subject);
        IMailBuilder WithBody(string body);
        IMailBuilder WithAttachment(params string[] attachments);
    }
}
