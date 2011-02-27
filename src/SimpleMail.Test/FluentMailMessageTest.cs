using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using SimpleMail.Mail;

namespace SimpleMail.Test
{
    [TestFixture]
    public class FluentMailMessageTest
    {
        [Test]
        public void FieldsMailMessageTest()
        {
            var newMessage = MailFactory.CreateNewFluentMailMessage()
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
                .WithBody("body");

            newMessage.Mail.FromAddress.Should().Be("from");
            newMessage.Mail.ToAddresses.Should().Contain("to");
            newMessage.Mail.ToAddresses.Should().Contain("to 2");
            newMessage.Mail.CcAddresses.Should().Contain("cc 1");
            newMessage.Mail.CcAddresses.Should().Contain("cc 2");
            newMessage.Mail.BccAddresses.Should().Contain("bcc 1");
            newMessage.Mail.BccAddresses.Should().Contain("bcc 2");
            newMessage.Mail.Attachments.Should().Contain("attachment 1");
            newMessage.Mail.Attachments.Should().Contain("attachment 2");
            newMessage.Mail.Body.Should().Be("body");
            newMessage.Mail.Subject.Should().Be("subject");
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
