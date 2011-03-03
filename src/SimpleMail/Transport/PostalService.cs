using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleMail.Mails;
using System.Net.Mail;

namespace SimpleMail.Transport
{
    public static class PostalService
    {
        private static MailTransportConfiguration _Configurations = new MailTransportConfiguration();
        
        public static FluentMail NewFluentMail()
        {
            return new FluentMail();
        }

        public static Mail NewMail()
        {
            return new Mail();
        }

        public static void Send(this IMail mail)
        {
            if (_Configurations.Smpt == null)
                throw new Exception();

            try
            {                
                _Configurations.Smpt.Send(ConvertIMailToMailMessage(mail));            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        private static MailMessage ConvertIMailToMailMessage(IMail mail)
        {
            MailMessage email = new MailMessage();
            email.Subject = mail.Subject;
            email.Body = mail.Body;
            email.From = new MailAddress(mail.FromAddress);            
            email.To.Add(GetAddress(mail.ToAddresses));
            if (mail.CcAddresses.Count > 0)
            email.CC.Add(GetAddress(mail.CcAddresses));
            if (mail.BccAddresses.Count > 0)
                email.Bcc.Add(GetAddress(mail.BccAddresses));
            email.IsBodyHtml = false;

            return email;
        }

        private static string GetAddress(ICollection<string> addresses)
        {
            var ColletionAddressess = new MailAddressCollection();
            foreach (var address in addresses)
            {
                ColletionAddressess.Add(new MailAddress(address));
            }

            return String.Join(",", ColletionAddressess.Select(address => address.Address).ToArray());            
        }
    }
}
