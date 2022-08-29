using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace Karakurt.MailManager
{
    public class MailSender
    {
        public static void Send(string filePath, bool isTest)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.energo-pro.com");
            mail.From = new MailAddress("kumanda.karakurt@energo-pro.com");

            List<string> mailToList = new List<string>();
            JObject jObject = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config.json"));

            DateTime pastDate = DateTime.Now.AddDays(-1);
            string zipFile = $@"C:\Users\Public\Documents\Reports\RGVK_KARAKURT_{pastDate.ToString("yyyyMMdd")}.zip";
            string zipFileEKB = $@"C:\Users\Public\Documents\Reports_ekb\EKB_KARAKURT_{pastDate.ToString("yyyyMMdd")}.zip";

            if (isTest)
            {
                mailToList = jObject["testMailTo"].ToString().Split(',').ToList();

                var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create);
                archive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                archive.Dispose();
            }
            else
            {
                mailToList = jObject["realMailTo"].ToString().Split(',').ToList();
            }

            foreach (var mailAddress in mailToList)
            {
                mail.To.Add(mailAddress);
            }

            mail.Subject = "Karakurt HES Reaktif Kontrol Raporu ve EKB Raporu";
            mail.Body = "Karakurt HES Reaktif Kontrol Raporu ve EKB raporu ektedir.\n\nKarakurt Kumanda";

            Attachment attachment;
            Attachment attachment_ekb;
            attachment = new Attachment(zipFile);
            attachment_ekb = new Attachment(zipFileEKB);
            mail.Attachments.Add(attachment);
            mail.Attachments.Add(attachment_ekb);

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(@"energopro\kumanda.karakurt", "Rt@mEp83");
            smtpClient.EnableSsl = false;

            smtpClient.Send(mail);

        }
    }
}
