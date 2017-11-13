using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.UserInfo;
using DAL.UserInfo;
using BLL.ErrorMessage;
using BLL.Utility;
using SHZSZHSUPPLY.VendorAssess.Util;
using BLL;

namespace SHZSZHSUPPLY
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["usernum"] == null)
            //{

            //    Response.Redirect("../Login.aspx");
            //    return;
            //}


            if (!IsPostBack)
            {
                Label2.Text = Request.QueryString["name1"];
                Label3.Text = Request.QueryString["name2"];

                iFrame1.Attributes.Add("src", "MainPage.aspx");

                try
                {
                    List<string> list = Employee_BLL.getAuthority(Session["Employee_ID"].ToString());

                    LocalScriptManager.CreateScript(Page, String.Format("filterNavigation('{0}', '{1}', '{2}', '{3}', '{4}')", list[0], list[1], list[2], list[3], list[4]), "dis");

                }
                catch (Exception)
                {
                    Console.WriteLine("read error");
                }
            }
            else
            {

            }
        }

        private void InitializeComponent()
        {
            this.Unload += new System.EventHandler(this.WebForm1_Unload);

        }

        private void WebForm1_Unload(object sender, EventArgs e)
        {
            BLL.Utility.SqlUtil Sqlutil = new BLL.Utility.SqlUtil();
            Sqlutil.Sqlclose();
        }





    }
}
