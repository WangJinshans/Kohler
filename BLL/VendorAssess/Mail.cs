using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;

namespace BLL.VendorAssess
{
    public class Mail
    {
        public static void flowToast(string aimEmail, string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other)
        {
            SmtpClient Smtp = null;
            MailMessage MailMessage = null;

            string path = HttpContext.Current.Server.MapPath("/VendorAssess/Html_Template/Mail_Template.html");
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

            MailMessage = new MailMessage();
            MailMessage.From = FromMailAddress;
            MailMessage.To.Add(ToMailAddress);
            MailMessage.Subject = "供应商审批";
            MailMessage.Body = mailtext;
            MailMessage.IsBodyHtml = true;

            Smtp = new SmtpClient();
            Smtp.Host = "apaccasarray.kohlerco.com";
            //Smtp.SendCompleted += Smtp_SendCompleted;

            Tuple<SmtpClient,MailMessage, string, string,string> tuple = Tuple.Create(Smtp,MailMessage,HttpContext.Current.Session["Employee_ID"].ToString(), other+"目标："+aimEmail, tempVendorID);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), tuple);
        }

        static void ThreadProc(object state)
        {
            Tuple<SmtpClient, MailMessage,string, string, string> tuple = (Tuple<SmtpClient , MailMessage,string, string, string>)state;
            SmtpClient Smtp = tuple.Item1;
            MailMessage MailMessage = tuple.Item2;
            try
            {
                //Smtp.SendCompleted += (s, e) =>
                //{
                //    string[] args = (string[])e.UserState;
                //    if (e.Cancelled)
                //    {
                //        Write_BLL.writeLog(HttpContext.Current.Session["Employee_ID"].ToString(), "", ("邮件已被取消内容：" + args[1]), As_Write.MAIL_CANCELLED, args[0]);
                //    }
                //    if (e.Error == null)
                //    {
                //        Write_BLL.writeLog(HttpContext.Current.Session["Employee_ID"].ToString(), "", ("邮件发送成功内容：" + args[1]), As_Write.MAIL_SUCCESS, args[0]);
                //    }
                //    else
                //    {
                //        Write_BLL.writeLog(HttpContext.Current.Session["Employee_ID"].ToString(), "", ("邮件发送失败内容：" + args[1]), As_Write.MAIL_ERROR, args[0]);
                //    }
                //};
                Smtp.SendAsync(MailMessage, new string[] { tuple.Item5, tuple.Item4 });
            }
            catch (Exception e)
            {
                Smtp.SendAsyncCancel();
                Write_BLL.writeLog(tuple.Item3, "", ("邮件发送失败内容：" + tuple.Item4), As_Write.MAIL_ERROR, tuple.Item5);
            }
            finally
            {
                MailMessage.Dispose();
                Smtp.Dispose();
            }
        }

        public static void backToast(string aimEmail, string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other)
        {
            string path = HttpContext.Current.Server.MapPath("/VendorAssess/Html_Template/Mail_Template.html");
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


            Tuple<SmtpClient, MailMessage, string, string, string> tuple = Tuple.Create(Smtp, MailMessage, HttpContext.Current.Session["Employee_ID"].ToString(), other + "目标：" + aimEmail, tempVendorID);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), tuple);
        }


        private static void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string[] args = (string[])e.UserState;
            if (e.Cancelled)
            {
                Write_BLL.writeLog(HttpContext.Current.Session["Employee_ID"].ToString(), "", ("邮件已被取消内容：" + args[1]), As_Write.MAIL_CANCELLED, args[0]);
            }
            if (e.Error == null)
            {
                Write_BLL.writeLog(HttpContext.Current.Session["Employee_ID"].ToString(), "", ("邮件发送成功内容：" + args[1]), As_Write.MAIL_SUCCESS, args[0]);
            }
            else
            {
                Write_BLL.writeLog(HttpContext.Current.Session["Employee_ID"].ToString(), "", ("邮件发送失败内容：" + args[1]), As_Write.MAIL_ERROR, args[0]);
            }
        }
    }
}
