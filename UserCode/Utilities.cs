using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace SamplesRepository.UserCode
{
    public static class Utilities
    {
        static Utilities()
        {

        }

        // Generic method for sending emails
        public static void SendMail(string from, string to, string subject,
        string body)
        {
            // Configure mail client
            SmtpClient mailClient = new SmtpClient(SamplesConfiguration.MailServer);
            // Set credentials (for SMTP servers that require authentication)
            mailClient.Credentials = new NetworkCredential(SamplesConfiguration.MailUsername, SamplesConfiguration.MailPassword);
            // Create the mail message
            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            // Send mail
            mailClient.Send(mailMessage);
        }

        // Send error log mail
        public static void LogError(Exception ex)
        {
            // get the current date and time
            string dateTime = DateTime.Now.ToLongDateString() + ", at "
                          + DateTime.Now.ToShortTimeString();
            // stores the error message
            string errorMessage = "Exception generated on " + dateTime;
            // obtain the page that generated the error
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            errorMessage += "\n\n Page location: " + context.Request.RawUrl;
            // build the error message
            errorMessage += "\n\n Message: " + ex.Message;
            errorMessage += "\n\n Source: " + ex.Source;
            errorMessage += "\n\n Method: " + ex.TargetSite;
            errorMessage += "\n\n Stack Trace: \n\n" + ex.StackTrace;
            // send error email in case the option is activated in Web.Config
            if (SamplesConfiguration.EnableErrorLogEmail)
            {
                string from = SamplesConfiguration.MailFrom;
                string to = SamplesConfiguration.ErrorLogEmail;
                string subject = "Samples Repository Report";
                string body = errorMessage;
                //SendMail(from, to, subject, body);
                //string filePath = @"D:\Error.txt";
                string filePath = HttpContext.Current.Server.MapPath("~/logs/logs.txt");
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                }
                using(StreamWriter sw=File.AppendText(filePath))
                {
                    sw.WriteLine(subject+"\n"+body);
                }
            }
        }
    }
}