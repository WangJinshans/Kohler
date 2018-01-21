using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using BLL.LDAP;
using BLL.UserInfo;
using DAL.UserInfo;
using Model;
using BLL;

namespace SHZSZHSUPPLY
{
    public partial class Login : System.Web.UI.Page
    {
        private List<As_Employee> employees;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string adPath = "LDAP://DC=kohlerco,DC=com";
            LdapAuthentication adAuth = new LdapAuthentication(adPath);
            const string usergroup = "SKZSZHSUPPLY";


            try
            {

                if (adAuth.IsAuthenticated(TextBox1.Text, TextBox2.Text) == true)

                {


                    string groups = adAuth.GetGroups();




                    if (groups.IndexOf(usergroup) < 0)

                    {

                        Label1.Text = "No permission to login ";

                        return;

                    }



                    string greet1 = adAuth.getdisplayname();
                    string urladdress;


                    //transfer display name by url
                    urladdress = "WebForm1.aspx?name1=" + greet1 + "&name2=" + TextBox1.Text;


                    //You can redirect now.

                    UserInfo_BLL UserInfo_BLL = new UserInfo_BLL();
                    List<UserInfo_BO> UserInfo_BO_List = new List<UserInfo_BO>();
                    UserInfo_BO_List = UserInfo_BLL.UserInfo_BLL_List(TextBox1.Text);

                    if (UserInfo_BO_List.Count == 0)
                    {
                        Session.Add("plantname", "无");
                    }

                    else
                    {
                        Session.Add("plantname", UserInfo_BO_List[0].Write_Plant.ToString());
                    }

                    Session.Add("usernum", TextBox1.Text);

                    Session.Timeout = 30;


                    //Response.Redirect(urladdress);


                    //初始化审批系统，并跳转
                    try
                    {
                        initVendorAssess(TextBox1.Text.Trim().ToLower());
                    }
                    catch (Exception error)
                    {
                        Label1.Text = "审批系统初始化异常："+error.Message;
                    }

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

        private void initVendorAssess(string employeeID)
        {
            if (EmployeeList.Visible)
            {
                EmployeeList.Visible = false;
                List<As_Employee> list = Employee_BLL.getEmolyeeListById(employeeID);
                string[] selection = EmployeeList.Text.Split('-');
                As_Employee ae = list
                    .FirstOrDefault(u => u.Factory_Name == selection[1] && u.Positon_Name == selection[0]);
                if (ae == null)
                {
                    throw new Exception("当前输入的信息不匹配");
                }
                Session["Employee_ID"] = ae.Employee_ID;
                Session["Employee_Name"] = ae.Employee_Name;
                Session["Position_Name"] = ae.Positon_Name;
                Session["Department_ID"] = ae.Department_ID;
                Session["Department_Name"] = ae.Department_Name;
                Session["Authority_ID"] = ae.Authority_ID;
                Session["Factory_Name"] = ae.Factory_Name;//获取厂名
                Response.Write("<script>parent.location.href='" + "./WebForm1.aspx?name1=" + ae.Employee_Name + "&name2=" + ae.Employee_ID + "'</script>");
                return;;
            }

            employees = Employee_BLL.getEmolyeeListById(employeeID);
            if (employees.Count>1)  //如果有多个记录
            {
                EmployeeList.DataSource = employees.Select(u=>u.Positon_Name+"-"+u.Factory_Name).ToList();
                EmployeeList.Visible = true;
                EmployeeList.DataBind();
                throw new Exception("请选择需要登陆的角色");
            }
            else
            {
                EmployeeList.Visible = false;
                Session["Employee_ID"] = employees[0].Employee_ID;
                Session["Employee_Name"] = employees[0].Employee_Name;
                Session["Position_Name"] = employees[0].Positon_Name;
                Session["Department_ID"] = employees[0].Department_ID;
                Session["Department_Name"] = employees[0].Department_Name;
                Session["Authority_ID"] = employees[0].Authority_ID;
                Session["Factory_Name"] = employees[0].Factory_Name;//获取厂名
                Response.Write("<script>parent.location.href='" + "./WebForm1.aspx?name1=" + employees[0].Employee_Name + "&name2=" + employees[0].Employee_ID + "'</script>");
            }

            
        }
    }
}