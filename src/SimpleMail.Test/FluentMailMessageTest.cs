using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using SimpleMail.Mails;
using SimpleMail.Transport;

namespace SimpleMail.Test
{
    [TestFixture]
    public class FluentMailMessageTest
    {
        [Test]
        public void FieldsMailMessageTest()
        {
            var mail = PostalService.NewFluentMail()
                .From("from")
                .To("to")
                .To("to 2")
                .Cc("cc 1")
                .Cc("cc 2")
                .Bcc("bcc 1")
                .Bcc("bcc 2")
                .WithSubject("subject")
                .WithAttachment("attachment 1")
                .WithAttachment("attachment 2")
                .WithBody("body")
                .Builder();
            
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

        [Test]
        public void SendMailTest()
        {
            //EmailTransportConfiguration.configure("smtp.server.com", true, false, "username", "password");

            try
            {
                //MailFactory.NewFluentMailMessage()
                //    .From("from")
                //    .To("to")
                //    .To("to 2")
                //    .Cc("cc 1")
                //    .Cc("cc 2")
                //    .Bcc("bcc 1")
                //    .Bcc("bcc 2")
                //    .WithSubject("subject")
                //    .WithAttachment("attachment 1")
                //    .WithAttachment("attachment 2")
                //    .WithBody("body")
                //    .Send();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
