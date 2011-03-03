using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleMail.Validation
{
    public static class MailAddressValidator
    {
        public static bool validate(string mailAddress)
        {
            string pattern = @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$";
            return (mailAddress != null || Regex.IsMatch(mailAddress, pattern));
        }
    }
}
