using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SimpleMail.Transport;
using SharpTestsEx;

namespace SimpleMail.Test
{
    [TestFixture]
    public class MailMessageTest
    {
        [Test]
        public void FieldsMailMessageTest()
        {
            var mail = PostalService.NewMail();                
            mail.FromAddress = "from";
            mail.ToAddresses.Add("to");
            mail.ToAddresses.Add("to 2");
            mail.CcAddresses.Add("cc 1");
            mail.CcAddresses.Add("cc 2");
            mail.BccAddresses.Add("bcc 1");
            mail.BccAddresses.Add("bcc 2");
            mail.Subject = "subject";
            mail.Attachments.Add("attachment 1");
            mail.Attachments.Add("attachment 2");
            mail.Body = "body";

            mail.FromAddress.Should().Be("from");
            mail.ToAddresses.Should().Contain("to");
            mail.ToAddresses.Should().Contain("to 2");
            mail.CcAddresses.Should().Contain("cc 1");
            mail.CcAddresses.Should().Contain("cc 2");
            mail.BccAddresses.Should().Contain("bcc 1");
            mail.BccAddresses.Should().Contain("bcc 2");
            mail.Attachments.Should().Contain("attachment 1");
            mail.Attachments.Should().Contain("attachment 2");
            mail.Body.Should().Be("body");
            mail.Subject.Should().Be("subject");
        }
    }
}
