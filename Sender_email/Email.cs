using System;
using System.ComponentModel;
using System.Net.Mail;
using AegisImplicitMail;

namespace Sender_email
{
    public class Email
    {
        private void SendEmail()
        {
            var mail = "info@enter-it.ru";
            var to = "rummolprod999@gmail.com";
            var host = "web07-cp.marosnet.net";
            var user = "info@enter-it.ru";
            var pass = "********";

            //Generate Message
            var mymessage = new MimeMailMessage();
            mymessage.From = new MimeMailAddress(mail);
            mymessage.To.Add(to);
            mymessage.Subject = "test";
            mymessage.Body = "body";

            //Create Smtp Client
            var mailer = new MimeMailer(host, 465);
            mailer.User = user;
            mailer.Password = pass;
            mailer.SslType = SslMode.Ssl;
            mailer.AuthenticationMode = AuthenticationType.Base64;

            //Set a delegate function for call back
            mailer.SendCompleted += compEvent;
            mailer.SendMailAsync(mymessage);
        }

        private void compEvent(object sender, AsyncCompletedEventArgs e)
        {
            if (e.UserState != null)
                Console.Out.WriteLine(e.UserState.ToString());

            Console.Out.WriteLine("is it canceled? " + e.Cancelled);

            if (e.Error != null)
                Console.Out.WriteLine("Error : " + e.Error.Message);
        }

        public void Sent()
        {
            SendEmail();
        }
    }
}