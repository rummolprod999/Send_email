using System;
using System.ComponentModel;
using System.Net.Mail;
using AegisImplicitMail;


namespace Sender_email
{
    class Program
    {
        static void Main(string[] args)
        {
            Email e = new Email();
            e.Sent();

        }

    }
}
