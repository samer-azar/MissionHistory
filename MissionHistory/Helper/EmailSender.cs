using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Helper
{
    public static class EmailSender
    {

        public static void SendEmailMessage(string to, string cc, string bcc, string subject, string body, AttachmentCollection attachments)
        {
            System.Net.Mail.MailAddress fromAddress, toAddress, ccAddress = null, bccAddress = null;
            System.Net.Mail.SmtpClient smtp;
            MailMessage message;

            try
            {
                fromAddress = new System.Net.Mail.MailAddress("lrcems402@gmail.com", "LRC_EMS_402_Automatic_System");
                const string fromPassword = "lrcems402chefsecteur";

                toAddress = new System.Net.Mail.MailAddress(to);

                if (cc != string.Empty)
                    ccAddress = new System.Net.Mail.MailAddress(bcc);

                if (bcc != string.Empty)
                    bccAddress = new System.Net.Mail.MailAddress(bcc);

                smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587, //465 is deprecated
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                message = new MailMessage(fromAddress, toAddress);

                if (bccAddress != null)
                    message.Bcc.Add(bccAddress);

                if (ccAddress != null)
                    message.CC.Add(ccAddress);

                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                if (attachments != null)
                {
                    foreach (System.Net.Mail.Attachment data in attachments)
                        message.Attachments.Add(data);
                }


                smtp.Send(message);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



    }
}
