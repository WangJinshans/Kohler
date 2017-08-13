using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices ;
using BLL.LDAP ;
using BLL.UserInfo;
using DAL.UserInfo;


namespace SHZSZHSUPPLY
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             string adPath  = "LDAP://DC=kohlerco,DC=com" ;
             LdapAuthentication  adAuth=new LdapAuthentication(adPath);
            const string  usergroup  = "SKZSZHSUPPLY";


      try
      {
               
                if (/*adAuth.IsAuthenticated(TextBox1.Text, TextBox2.Text==*/true) 
                
                {
                          
                
               //string groups  = adAuth.GetGroups();



              
                //if (groups.IndexOf(usergroup) <0) 

                //    {
                       
                //    Label1.Text = "No permission to login ";

                //        //return;
                   
                //    }

               
                
               //string greet1 = adAuth.getdisplayname();
               string urladdress ;
                              

                //transfer display name by url
                urladdress = "WebForm1.aspx?name1=" + "Linda.Li" + "&name2=" + "ko18524";
                
              
                //You can redirect now.

                UserInfo_BLL UserInfo_BLL = new UserInfo_BLL();
                List<UserInfo_BO> UserInfo_BO_List = new List<UserInfo_BO>();
                //UserInfo_BO_List = UserInfo_BLL.UserInfo_BLL_List(TextBox1.Text);

                if (UserInfo_BO_List.Count == 0)
                {
                    Session.Add("plantname", "上海科勒");
                }

                else
                {
                    Session.Add("plantname", UserInfo_BO_List[0].Write_Plant.ToString());
                }
                                
                Session.Add("usernum", TextBox1.Text);

                Session.Timeout = 30;

              
                
                Response.Redirect(urladdress);


               


               
                }
          else
          {
          
                Label1.Text = "错误的用户名和密码";
                }
      }
        catch 
            {
            Label1.Text = "Error authenticating user";
            }



        }
    }
}