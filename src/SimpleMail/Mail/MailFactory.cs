using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMail.Mail
{
    public static class MailFactory
    {
        public static MailMessage CreateNewMailMessage()
        {
            return new MailMessage();
        }

        public static FluentMailMessage CreateNewFluentMailMessage()
        {
            return new FluentMailMessage();
        }
    }
}
