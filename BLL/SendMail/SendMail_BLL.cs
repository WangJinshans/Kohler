using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using BLL.PlantInfo;
using DAL.PlantInfo;
using BO.PlantInfo ;
using BLL.ItemNotifyInfo;
using BO.ItemNotifyInfo;



namespace BLL.SendMail
{
    public class SendMail_BLL
    {
        public void SendMail_BLL_Plant(string plantname,string vendercode,string vendername,string vendertype,string venderoldstate,string vendernewstate,string usernum,string reason)
        {
            //PlantInfo_BLL PlantInfo_BLL = new PlantInfo_BLL();
            //List<PlantInfo_BO > PlantInfo_BO=new List<PlantInfo_BO >();
            //PlantInfo_BO = PlantInfo_BLL.PlantInfo_BLL_List_Plant(plantname);

            List<PlantInfo_BO> PlantInfo_BO_List = new List<PlantInfo_BO>();
            PlantInfo_BLL PlantInfo_BLL = new PlantInfo_BLL();
            PlantInfo_BO_List = PlantInfo_BLL.PlantInfo_BLL_List_Plant(plantname);

            string TomailAddress = PlantInfo_BO_List[0].Notify_User;
            string mailtext ="<p>"+usernum +"</p>"+"<p>"+DateTime .Now .ToShortDateString ()+"</p>"+"<p>"+reason +"</p>"+
            "<div style=\"width:820px;height:90px\"><table cellpadding =\"0\" cellspacing =\"0\" style=\"width:820px;height:30px\"><tr><td style=\"  text-align :center ; background-color :Green; border-bottom : 1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black; border-top :1.0pt solid black  \">供应商状态</td></tr></table>"+
            "<table cellpadding =\"0\" cellspacing =\"0\"><tr><td style=\"width:120px; height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :small\">工厂</td>"+
            "<td style=\"width:110px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">供应商代码</td>"+
            "<td style=\"width:300px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">供应商名称</td>"+
              "<td style=\"width:150px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">供应商类型</td>" +
            "<td style=\"width:70px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">原状态</td>"+
            "<td style=\"width:70px; border-bottom :1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black;font-size :smaller\">现状态</td>" +
            "</tr></table> <table cellpadding =\"0\" cellspacing =\"0\"><tr><td style=\"width:120px; height:30px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">" + plantname + "</td>" +
            "<td style=\"width:110px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">" + vendercode + "</td>"+
            "<td  style=\"width:300px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">" + vendername + "</td>"+
             "<td  style=\"width:150px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">" + vendertype + "</td>" +
            "<td style=\"width:70px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller\">" + venderoldstate + "</td>" +
            "<td style=\"width:70px;border-bottom :1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black;font-size :smaller\">" + vendernewstate + "</td>" +
            "</tr></table></div><p>" + plantname + "</p><p>" + DateTime.Now.ToShortDateString() + "</p> ";
            MailAddress ToMailAddress = new MailAddress(PlantInfo_BO_List [0].Notify_User );
            MailAddress FromMailAddress=new MailAddress ("SKZSZHSUPPLY@kohler.com");

            MailMessage MailMessage = new MailMessage();
            MailMessage.From= FromMailAddress ;
            MailMessage.To.Add ( ToMailAddress);
            MailMessage.Subject = "供应商状态";
            MailMessage.Body = mailtext;
            MailMessage.IsBodyHtml = true;

            SmtpClient Smtp = new SmtpClient();
            Smtp.Host = "apaccasarray.kohlerco.com";
            Smtp.Send(MailMessage);
        }

        public void Sendmail_BLL_Item(string vendercode, string itemcategory, string plantname, string vendertype,string itemstate, string itemlabel, string startdate, string enddate, string uploaduser, string uploaddate, string reason, string usernum)
        {
           List<ItemNotify_BO > ItemNotify_BO_List =new List <ItemNotify_BO >();
           ItemNotify_BLL ItemNotify_BLL = new ItemNotify_BLL();
           ItemNotify_BO_List = ItemNotify_BLL.ItemNotify_BLL_DeleteUser_Plant(plantname);

            string TomailAddress = ItemNotify_BO_List[0].Item_Notify_Delete_User ;
            string mailtext = "<p>" + usernum + "</p>" + "<p>" + DateTime.Now.ToShortDateString() + "</p>" + "<p>" + reason + "</p>" + 
            "<div style=\"width:1150px ;height:30px\"><table cellpadding =\"0\" cellspacing =\"0\" style=\"width:1150px;height:30px\"><tr><td style=\"width:1150px;height:30px;text-align :center; background-color :Green; border-bottom : 1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black; border-top :1.0pt solid black \">"+
            "文档删除</td></tr></table></div>"+
            "<div style=\"width:1150px ;height:30px\"><table cellpadding =\"0\" cellspacing =\"0\" style=\"width:1150px;height:30px\">" +
            "<tr><td style=\"width:100px;height:30px;border-bottom : 1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \" >供应商代码</td>" +
            "<td style=\"width:190px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">文档类型</td>" +
            "<td style=\"width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">文档工厂</td>" +
             "<td style=\"width:150px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">文档供应商</td>" +
            "<td style=\"width:60px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">文档状态</td>" +
            "<td style=\"width:240px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">文档条码</td>" +
            "<td style=\"width:90px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">起始</td>" +
            "<td style=\"width:90px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">结束</td>" +
            "<td  style=\"width:90px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">上传日期</td>" +
            "<td style=\"width:60px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black;font-size :smaller \">上传用户</td>" +
            "</tr></table></div>"+
            "<div style=\"width:1150px ;height:30px\"><table cellpadding =\"0\" cellspacing =\"0\" style=\"width:1150px;height:30px\">" +
            "<tr><td style=\"width:100px;height:30px;border-bottom : 1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \" >"+vendercode +"</td>" +
            "<td style=\"width:190px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">"+itemcategory +"</td>" +
            "<td style=\"width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">"+plantname +"</td>" +
             "<td style=\"width:150px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">" + vendertype + "</td>" +
            "<td style=\"width:60px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">"+itemstate +"</td>" +
            "<td style=\"width:240px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">"+itemlabel +"</td>" +
            "<td style=\"width:90px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">"+startdate +"</td>" +
            "<td style=\"width:90px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">"+enddate +"</td>" +
            "<td  style=\"width:90px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;font-size :smaller \">"+uploaddate +"</td>" +
            "<td style=\"width:60px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black;font-size :smaller \">"+uploaduser +"</td>" +
            "</tr></table></div>"+
            "<p> "+plantname +"</p><p>"+DateTime .Now .ToShortDateString ()+"</p>";

            MailAddress ToMailAddress = new MailAddress(TomailAddress);
            MailAddress FromMailAddress = new MailAddress("SKZSZHSUPPLY@kohler.com");

            MailMessage MailMessage = new MailMessage();
            MailMessage.From = FromMailAddress;
            MailMessage.To.Add(ToMailAddress);
            MailMessage.Subject = "文档删除";
            MailMessage.Body = mailtext;
            MailMessage.IsBodyHtml = true;

            SmtpClient Smtp = new SmtpClient();
            Smtp.Host = "apaccasarray.kohlerco.com";
            Smtp.Send(MailMessage);
        }
    }
}
