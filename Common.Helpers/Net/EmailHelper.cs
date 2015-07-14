namespace Common.Helpers.Net
{
    using System;
    
    using System.Net.Mail;

    public static class EmailHelper
    {
        /// <summary>
        ///  Sends an email
        /// </summary>
        /// <param name="fromEmailAddress"></param>
        /// <param name="fromDisplayName"></param>
        /// <param name="toEmailAddress"></param>
        /// <param name="toDisplayName"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isBodyHtml"></param>
        /// <returns></returns>
        public static bool SendEmail(string fromEmailAddress, string fromDisplayName, 
                                        string toEmailAddress, string toDisplayName,
                                        string subject, string body, bool isBodyHtml)
        {
            var fromAddress = new MailAddress(fromEmailAddress, fromDisplayName);
            var toAddress = new MailAddress(toEmailAddress, toDisplayName);

            var message = new MailMessage(fromAddress, toAddress);
            message.IsBodyHtml = isBodyHtml;
            message.Subject = subject;
            message.Body = body;

            var smtp = new SmtpClient();
            smtp.Send(message);
                        
            return true;
        }
    }
}
