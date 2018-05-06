using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.LDAP;
using BLL.UserInfo;
using DAL.UserInfo;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace AendorAssess
{
    public partial class login : System.Web.UI.Page
    {
        private List<As_Employee> employees;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (true)
                {

                    
                    //初始化审批系统，并跳转
                    try
                    {
                        //LocalScriptManager.CreateScript(Page, String.Format("setSession('{0}')", TextBox1.Text.Trim().ToLower()), "sessionValues");
                        string uid = Convert.ToString(Session["Employee_ID"]);
                        if (uid != "" && !uid.Equals(TextBox1.Text.Trim().ToLower()))
                        {
                            LocalScriptManager.CreateScript(Page, String.Format("setSession('{0}')", TextBox1.Text.Trim().ToLower()), "sessionValues");
                        }
                        initVendorAssess(TextBox1.Text.Trim().ToLower());
                    }
                    catch (Exception error)
                    {
                        Label1.Text = "审批系统初始化异常：" + error.Message;
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
                //模拟登陆管理系统
                Session.Add("usernum", ae.Employee_ID);
                Session.Add("plantname", ae.Factory_Name);
                //LocalScriptManager.CreateScript(Page, String.Format("setuid('{0}')", ae.Employee_ID), "uidvalue");
                LocalScriptManager.CreateScript(Page, String.Format("redirecturl('{0}','{1}')", ae.Employee_Name,ae.Employee_ID), "redirecturl");
                //Response.Write("<script>parent.location.href='" + "../WebForm1.aspx?name1=" + ae.Employee_Name + "&name2=" + ae.Employee_ID + "'</script>");
                return;
            }

            employees = Employee_BLL.getEmolyeeListById(employeeID);
            if (employees.Count > 1)  //如果有多个记录
            {
                EmployeeList.DataSource = employees.Select(u => u.Positon_Name + "-" + u.Factory_Name).ToList();
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
                //模拟登陆管理系统
                Session.Add("usernum", employees[0].Employee_ID);
                Session.Add("plantname", employees[0].Factory_Name);
                LocalScriptManager.CreateScript(Page, String.Format("redirecturl('{0}','{1}')", employees[0].Employee_Name, employees[0].Employee_ID), "redirecturl");
                //Response.Write("<script>parent.location.href='" + "../WebForm1.aspx?name1=" + employees[0].Employee_Name + "&name2=" + employees[0].Employee_ID + "'</script>");
            }


        }
    }
}


//namespace AendorAssess
//{
//    public partial class login : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }

//        protected void Button2_Click(object sender, EventArgs e)
//        {
//            string employee_ID = Employee_ID.Text.Trim();
//            string employee_Password = Employee_Password.Text.Trim();
//            As_Employee employee = Employee_BLL.getEmolyeeListById(employee_ID).FirstOrDefault();
//            string employee_id = employee.Employee_Password;
//            if (employee_id == employee_Password)
//            {
//                Session["Employee_ID"] = employee.Employee_ID;
//                Session["Employee_Name"] = employee.Employee_Name;
//                Session["Position_Name"] = employee.Positon_Name;
//                Session["Factory_Name"] = employee.Factory_Name;//获取厂名
//                Session["Position_Name"] = employee.Positon_Name;
//                Session["Department_ID"] = employee.Department_ID;
//                Session["Department_Name"] = employee.Department_Name;
//                Session["Authority_ID"] = employee.Authority_ID;
//                //模拟登陆管理系统
//                Session.Add("usernum", employee.Employee_ID);
//                Session.Add("plantname", employee.Factory_Name);

//                //Response.Redirect("../WebForm1.aspx?name1=" + employee.Employee_Name + "&name2=" + employee.Employee_ID);
//                Response.Write("<script>parent.location.href='"+ "../WebForm1.aspx?name1=" + employee.Employee_Name + "&name2=" + employee.Employee_ID + "'</script>");
//            }
//            else
//            {
//                //Response.Redirect("index.aspx");
//            }
//        }
//    }
////}