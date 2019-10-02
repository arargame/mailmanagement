using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailManagement;
using System.Net.Mail;
using System.Net;

namespace TestProject
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //var mm = new MailManager(smtpClientHost: "host", smtpClientPort: 587, smtpClientUser: "user", smtpClientPassword: "psswwrrdd");
            //var mm = MailManager.Gmail("yourmail@gmail.com","password");
            var mm = MailManager.Microsoft("yourmail@hotmail.com","password");

            var mail = new Mail(new MailAddress("test@hotmail.com", "Koray Arar(DP)"), null, "Subject", "<b>Body</b>");

            mail.AddTo(new MailAddress("toAddress@domain.com"));

            mail.AddCC();

            mm.Prepare(mail);
            
            ////
            var logAction = new Action<Exception>((ex) =>
            {
                Console.WriteLine(ex.ToString());

                Console.ReadLine();
            });

            mm.Send(logAction);
        }
    }
}
