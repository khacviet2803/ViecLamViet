using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebDemo.Utils
{
   public class XMailer
    {
        static String email = "1624801030118@student.tdmu.edu.vn";//vui lòng sửa mail của bạn
        static String password = "yuuki2803";//vui lòng sửa password của bạn

        // Gửi mail từ hệ thống
        public static void Send(String to, String subject, String body, HttpPostedFileBase fileUploader)
        {
            String from = email;
            XMailer.Send(from, to, "", "", subject, body, "", fileUploader);
        }

        // Gửi mail đơn giản
        public static void Send(String from, String to, String subject, String body, HttpPostedFileBase fileUploader)
        {
            XMailer.Send(from, to, "", "", subject, body, "", fileUploader);
        }

        // Gửi mail nhiều lựa chọn đầy đủ
        public static void Send(String from, String to, String cc, String bcc, String subject, String body, String attachments, HttpPostedFileBase fileUploader)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.ReplyTo = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            if (!String.IsNullOrEmpty(cc))
            {
                mail.CC.Add(cc);
            }
            if (!String.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(bcc);
            }
            if (!String.IsNullOrEmpty(attachments))
            {
                String[] fileNames = attachments.Split(";,".ToCharArray());
                foreach (String fileName in fileNames)
                {
                    if (fileName.Trim().Length > 0)
                    {
                        mail.Attachments.Add(new Attachment(fileName.Trim()));
                    }
                }
            }
            if (fileUploader != null)

            {

                string fileName = Path.GetFileName(fileUploader.FileName);

                mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

            }
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(email, password);
            client.Send(mail);
        }
    }
}
