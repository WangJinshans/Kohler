using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.VenderInfo;
using BLL.VenderInfo ;

namespace SHZSZHSUPPLY.VenderInfo
{
    public partial class VenderInfoDisplay : System.Web .UI .Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usernum"] == null)
            {

                Response.Redirect("../Login.aspx");
                return;
            }

            if (IsPostBack == false)
            {
                DropDownList1.SelectedValue = Session["plantname"].ToString();
                List<VenderList_BO> VenderList_BO_ListAll = new List<VenderList_BO>();
                VenderList_BLL VenderList_BLL = new VenderList_BLL();
                VenderList_BO_ListAll = VenderList_BLL.VenderList_BLL_ListAll();
                DropDownList2.DataSource = VenderList_BO_ListAll;
                DropDownList2.DataTextField = "vender_code";
                DropDownList2.DataValueField = "vender_code";
                DropDownList2.DataBind();

                if (Session.Count > 0)
                {
                    foreach (string key in Session.Keys)
                    {

                        if (key == "vendercodeExist")
                        {
                            DropDownList2.SelectedValue = Session["vendercodeExist"].ToString();
                            DropDownList3.SelectedValue = Session["vendertypeExist"].ToString();


                        }


                    }

                    Session.Remove("vendercodeExist");
                    Session.Remove("vendertypeExist");
                }

                List<VenderType_BO> VenderType_BO_List = new List<VenderType_BO>();
                VenderType_BLL Vendertype_BLL = new VenderType_BLL();
           


                List<VenderList_BO> VenderList_BO_List = new List<VenderList_BO>();
                VenderList_BO_List = VenderList_BLL.VenderList_BLL_List(DropDownList2.SelectedValue);

                if (VenderList_BO_List.Count > 0)
                {
                    Label1.Text = VenderList_BO_List[0].Vender_Name;
                }
                else
                {
                    return;
                }
            }
        }

      

        protected void Button1_Click1(object sender, EventArgs e)
        {
          
            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
    


            ItemList_BLL ItemList_BLL = new ItemList_BLL();
            List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
            ItemList_BO = ItemList_BLL.ItemList_BLL_List( DropDownList2.SelectedValue );
            GridView3.DataSource = ItemList_BO;
            GridView3.DataBind();


            List<VenderPlantList_BO> venderplant = new List<VenderPlantList_BO>();
            venderplant = VenderPlantList_BLL.VenderPlantList_BLL_ListAll(DropDownList2.SelectedValue);
            GridView4.DataSource = venderplant;
            GridView4.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<VenderList_BO> VenderList_BO_List = new List<VenderList_BO>();
            VenderList_BLL VenderList_BLL_List = new VenderList_BLL();

            List<VenderType_BO> VenderType_BO_List = new List<VenderType_BO>();
            VenderType_BLL Vendertype_BLL = new VenderType_BLL();
       
            


            VenderList_BO_List = VenderList_BLL_List.VenderList_BLL_List(DropDownList2.SelectedValue );
            Label1.Text = VenderList_BO_List[0].Vender_Name;
        }

      

      
    }
}