using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMail.Mails
{
    public static class MailFactory
    {
        public static Mail CreateNewMailMessage()
        {
            return new Mail();
        }

        public static FluentMail CreateNewFluentMailMessage()
        {
            return new FluentMail();
        }
    }
}
