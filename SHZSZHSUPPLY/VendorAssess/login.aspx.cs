using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string employee_ID = Employee_ID.Text.Trim();
            string employee_Password = Employee_Password.Text.Trim();
            As_Employee employee = Employee_BLL.getEmolyeeById(employee_ID);
            string employee_id = employee.Employee_Password;
            if (employee_id == employee_Password)
            {
                Session["Employee_ID"] = employee.Employee_ID;
                Session["Employee_Name"] = employee.Employee_Name;
                Session["Position_Name"] = employee.Positon_Name;
                Response.Redirect("index.aspx");
            }
            else
            {
                //Response.Redirect("index.aspx");
            }
        }
    }
}