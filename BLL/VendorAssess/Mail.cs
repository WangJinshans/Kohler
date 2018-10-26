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
        public static void flowToast(string aimEmail, string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other,string formID)
        {
            SmtpClient Smtp = null;
            MailMessage MailMessage = null;

            string path = HttpContext.Current.Server.MapPath("~/VendorAssess/Html_Template/Mail_Template.html");
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            sr.Close();

            content = content.Replace("$mailTitle", "供应商审批流程通知");
            content = content.Replace("$otherTitle", "审批通知");
            content = content.Replace("$date", DateTime.Now.ToString());
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

            Smtp = new SmtpClient(); //apaccasarray.kohlerco.com

            Smtp.Host = "10.20.67.10";
            Smtp.Timeout = 30000;
            Smtp.SendCompleted += Smtp_SendCompleted;

            //string formID = FormType_BLL.getFormID(tempVendorID, formTypeName);
            Tuple<SmtpClient,MailMessage, string, string,string,string> tuple = Tuple.Create(Smtp,MailMessage,HttpContext.Current.Session["Employee_ID"].ToString(), other+"目标："+aimEmail, tempVendorID,formID);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), tuple);
        }

        static void ThreadProc(object state)
        {
            Tuple<SmtpClient, MailMessage,string, string, string,string> tuple = (Tuple<SmtpClient , MailMessage,string, string, string,string>)state;
            SmtpClient Smtp = tuple.Item1;
            MailMessage MailMessage = tuple.Item2;
            try
            {
                // 参数:
                //   from:
                //     包含邮件发件人的地址信息的 System.String。
                //   recipients:
                //     包含邮件收件人的地址的 System.String。
                //   subject:
                //     包含邮件主题行的 System.String。
                //   body:
                //     包含邮件正文的 System.String。
                //   userToken:
                //     一个用户定义对象，此对象将被传递给完成异步操作时所调用的方法。
                Smtp.SendAsync(MailMessage, new string[] { tuple.Item5, tuple.Item4, tuple.Item3, tuple.Item6 });
            }
            catch (Exception e)
            {
                Smtp.SendAsyncCancel();
                try
                {
                    Write_BLL.writeLog(tuple.Item3,tuple.Item6, ("邮件发送失败内容：" + tuple.Item4), As_Write.MAIL_ERROR, tuple.Item5);
                }
                catch (Exception)
                {

                }
            }
            finally
            {
            }
        }

        public static void backToast(string aimEmail, string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other,string formID)
        {
            string path = HttpContext.Current.Server.MapPath("~/VendorAssess/Html_Template/Mail_Template.html");
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            sr.Close();

            content = content.Replace("$mailTitle", "供应商审批流程通知");
            content = content.Replace("$otherTitle", "回返通知");
            content = content.Replace("$date", DateTime.Now.ToString());
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
            Smtp.Host = "10.20.67.10";
            Smtp.Timeout = 30000;
            Smtp.SendCompleted += Smtp_SendCompleted;

            //string formID = FormType_BLL.getFormID(tempVendorID, formTypeName);
            Tuple<SmtpClient, MailMessage, string, string, string,string> tuple = Tuple.Create(Smtp, MailMessage, HttpContext.Current.Session["Employee_ID"].ToString(), other + "目标：" + aimEmail, tempVendorID,formID);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), tuple);
        }


        private static void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string[] args = (string[])e.UserState;
            if (e.Cancelled)
            {
                Write_BLL.writeLog(args[2], args[3], ("邮件已被取消内容：" + args[1]), As_Write.MAIL_CANCELLED, args[0]);
            }
            if (e.Error == null)
            {
                Write_BLL.writeLog(args[2], args[3], ("邮件发送成功内容：" + args[1]), As_Write.MAIL_SUCCESS, args[0]);
            }
            else
            {
                Console.WriteLine(e.Error.Message);
                Write_BLL.writeLog(args[2], args[3], ("邮件发送失败内容：" + args[1]), As_Write.MAIL_ERROR, args[0]);
            }
        }


        /// <summary>
        /// MBR群发通知
        /// </summary>
        /// <param name="aimEmails"></param>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="tempVendorName"></param>
        /// <param name="patchNo"></param>
        /// <param name="msg"></param>
        public static void sendInspectionMail(List<string> aimEmails, string name, string factory, string tempVendorID, string tempVendorName, string patchNo, string msg)
        {
            SmtpClient Smtp = null;
            MailMessage MailMessage = null;

            string path = HttpContext.Current.Server.MapPath("~/VendorQualityDetection/Html/Mail_Template.html");
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            sr.Close();

            content = content.Replace("$mailTitle", "检验通知");
            content = content.Replace("$date", DateTime.Now.ToString());
            content = content.Replace("$name", name);
            content = content.Replace("$tempVendorID", tempVendorID);
            content = content.Replace("$tempVendorName", tempVendorName);
            content = content.Replace("$patchNo", patchNo);
            content = content.Replace("$time", DateTime.Now.ToString());
            content = content.Replace("$operation", msg);
            content = content.Replace("$factoryName", factory);

            string mailtext = content;
           
            MailAddress FromMailAddress = new MailAddress("SKZSZHSUPPLY@kohler.com");

            MailMessage = new MailMessage();
            MailMessage.From = FromMailAddress;

            MailAddress ToMailAddress = null;
            string email_list = "";
            foreach (string aimEmail in aimEmails)
            {
                ToMailAddress = new MailAddress(aimEmail);
                MailMessage.To.Add(ToMailAddress);
                email_list = aimEmail + "、";
            }

            MailMessage.Subject = "供应商审批";
            MailMessage.Body = mailtext;
            MailMessage.SubjectEncoding = Encoding.UTF8;
            MailMessage.IsBodyHtml = true;
            MailMessage.BodyEncoding = Encoding.UTF8;

            Smtp = new SmtpClient(); //apaccasarray.kohlerco.com

            Smtp.Host = "10.20.67.10";
            Smtp.Timeout = 30000;
            Smtp.SendCompleted += Smtp_SendCompleted;


            // I don't know what is this for
            string other = "";
            //string formID = FormType_BLL.getFormID(tempVendorID, formTypeName);
            Tuple<SmtpClient, MailMessage, string, string, string, string> tuple = Tuple.Create(Smtp, MailMessage, HttpContext.Current.Session["Employee_ID"].ToString(), other + "目标：" + email_list, tempVendorID, tempVendorName);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), tuple);
        }

    }
}
