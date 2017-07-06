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




namespace SHZSZHSUPPLY
{
    public partial class WebForm1 : System.Web .UI .Page  
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["usernum"] == null)
            //{

            //    Response.Redirect("../Login.aspx");
            //    return;
            //}
           

            Label2.Text = Request.QueryString ["name1"];
            Label3.Text = Request.QueryString["name2"];

            iFrame1.Attributes.Add("src", "MainPage.aspx");
       


        }

        private void InitializeComponent()
        {
            this.Unload += new System.EventHandler(this.WebForm1_Unload);

        }

        private void WebForm1_Unload(object sender, EventArgs e)
        {
            BLL.Utility.SqlUtil  Sqlutil = new BLL.Utility.SqlUtil ();
            Sqlutil.Sqlclose();
        }

      

    


} 
    }
