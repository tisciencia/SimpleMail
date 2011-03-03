using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using SimpleMail.Transport;
using System.Net.Mail;

namespace SimpleMail.Test
{
    [TestFixture]
    public class PostalServiceTest
    {
        [Test]
        public void SendFluentMail()
        {
            try
            {
                PostalService.NewFluentMail()
                    .From("caco_rp@yahoo.com.br")
                    .To("tisciencia@gmail.com")
                    .WithSubject("teste de envio de email")
                    .WithBody("Hello World!")
                    .Builder()
                    .Send();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void SendMail()
        {
            var mail = PostalService.NewMail();
            mail.FromAddress = "from";
            mail.ToAddresses.Add("to");
            mail.Subject = "subject";
            mail.Body = "body";
            mail.Validate();
            mail.Send();
        }

    }
}
