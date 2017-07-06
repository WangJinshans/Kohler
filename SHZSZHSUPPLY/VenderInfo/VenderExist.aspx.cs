using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.VenderInfo;
using BO.VenderInfo;

namespace SHZSZHSUPPLY.VenderInfo
{
    public partial class VenderExist : System.Web .UI.Page  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["usernum"] == null)
            //{

            //    Response.Redirect("../Login.aspx");
            //    return;
            //}

            if (IsPostBack == false)
            {
                Session.Add("vendercodeExist", Session["vendercode"].ToString());
                Session.Add("vendertypeExist", Session["vendertype"].ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OperationLog_BLL OperationLog_Bll = new OperationLog_BLL();
            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
            List<VenderPlantList_BO > VenderPlantList_BO_List = new List<VenderPlantList_BO >();
            VenderPlantList_BO_List = VenderPlantList_BLL.VenderPlantList_BLL_List (Session["vendercode"].ToString (),Session["plantname"].ToString(),Session["vendertype"].ToString ());

            if (VenderPlantList_BO_List.Count == 0)
            {
                VenderPlantList_BLL.VenderPlantList_BLL_Insert(Session["vendercode"].ToString(), Session["plantname"].ToString(), "Hold",Session["vendertype"].ToString ());
                OperationLog_Bll.VenderOperationLog_BLL_Insert(Session["vendercode"].ToString(), Session["vendertype"].ToString(), Session["plantname"].ToString(), "Hold", Session["usernum"].ToString());
            }

          
           this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>webform1_iframe_redirect_VenderMaintenance();</script>");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }

       

       
    }
}