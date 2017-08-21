using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace BLL.VendorAssess
{
    public class Mail
    {
        public static void flowToast(string aimEmail,string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other)
        {
            string path = HttpContext.Current.Server.MapPath("./Html_Template/Mail_Template.html");
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            sr.Close();

            content = content.Replace("$mailTitle", "供应商审批流程通知");
            content = content.Replace("$otherTitle", "审批通知");
            content = content.Replace("$date", DateTime.Now.ToLocalTime().ToString());
            content = content.Replace("$name", name);
            content = content.Replace("$factoryName", factory);
            content = content.Replace("$tempVendorID", tempVendorID);
            content = content.Replace("$tempVendorName", tempVendorName);
            content = content.Replace("$formTypeName", formTypeName);
            content = content.Replace("$formStatus", status);
            content = content.Replace("$lastOPTime", lastTime);
            content = content.Replace("$other", other);

            string mailtext = content;
            MailAddress ToMailAddress = new MailAddress(aimEmail);
            MailAddress FromMailAddress = new MailAddress("SKZSZHSUPPLY@kohler.com");

            MailMessage MailMessage = new MailMessage();
            MailMessage.From = FromMailAddress;
            MailMessage.To.Add(ToMailAddress);
            MailMessage.Subject = "供应商审批";
            MailMessage.Body = mailtext;
            MailMessage.IsBodyHtml = true;

            SmtpClient Smtp = new SmtpClient();
            Smtp.Host = "apaccasarray.kohlerco.com";
            Smtp.SendCompleted += Smtp_SendCompleted;

            Smtp.SendAsync(MailMessage, MailMessage.To);
        }

        public static void backToast(string aimEmail, string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other)
        {
            string path = HttpContext.Current.Server.MapPath("./Html_Template/Mail_Template.html");
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            sr.Close();

            content = content.Replace("$mailTitle", "供应商审批流程通知");
            content = content.Replace("$otherTitle", "回返通知");
            content = content.Replace("$date", DateTime.Now.ToLocalTime().ToString());
            content = content.Replace("$name", name);
            content = content.Replace("$factoryName", factory);
            content = content.Replace("$tempVendorID", tempVendorID);
            content = content.Replace("$tempVendorName", tempVendorName);
            content = content.Replace("$formTypeName", formTypeName);
            content = content.Replace("$formStatus", status);
            content = content.Replace("$lastOPTime", lastTime);
            content = content.Replace("$other", other);

            string mailtext = content;
            MailAddress ToMailAddress = new MailAddress(aimEmail);
            MailAddress FromMailAddress = new MailAddress("SKZSZHSUPPLY@kohler.com");

            MailMessage MailMessage = new MailMessage();
            MailMessage.From = FromMailAddress;
            MailMessage.To.Add(ToMailAddress);
            MailMessage.Subject = "供应商审批";
            MailMessage.Body = mailtext;
            MailMessage.IsBodyHtml = true;

            SmtpClient Smtp = new SmtpClient();
            Smtp.Host = "apaccasarray.kohlerco.com";
            Smtp.SendCompleted += Smtp_SendCompleted;

            Smtp.SendAsync(MailMessage, MailMessage.To);
        }

        private static void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("cancel");
            }
            if (e.Error == null)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
