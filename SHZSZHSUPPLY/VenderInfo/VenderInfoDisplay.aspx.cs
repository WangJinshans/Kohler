using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.VenderInfo;
using BLL.VenderInfo;
using System.Web.Script.Serialization;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace SHZSZHSUPPLY.VenderInfo
{
    public partial class VenderInfoDisplay : System.Web .UI .Page 
    {
        private static string factory_Name = "";
        private static string serializedJson;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usernum"] == null)
            {
                Response.Redirect("../Login.aspx");
                return;
            }

            factory_Name = Session["plantname"].ToString();
            if (!IsPostBack)
            {
                VenderList_BLL VenderList_BLL = new VenderList_BLL();
                List<string> vendorList = VenderList_BLL.listAllVendor(factory_Name);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                serializedJson=jss.Serialize(vendorList);
                LocalScriptManager.CreateScript(Page, String.Format("setParameters('{0}','{1}')",factory_Name, serializedJson), "serparams");
            }
            else
            {
                //处理PostPack
                switch (Request["__EVENTTARGET"])
                {
                    case "getVendorInfo":
                        getVendorInfo(factory_Name, Request["__EVENTARGUMENT"]);
                        break;
                }
            }
        }

        private void getVendorInfo(string factory_Name, string vendorCode)
        {
            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
            ItemList_BLL ItemList_BLL = new ItemList_BLL();
            List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
            ItemList_BO = ItemList_BLL.ItemList_BLL_List(vendorCode);
            GridView3.DataSource = ItemList_BO;
            GridView3.DataBind();
            List<VenderPlantList_BO> venderplant = new List<VenderPlantList_BO>();
            venderplant = VenderPlantList_BLL.VenderPlantList_BLL_ListAll(vendorCode);
            GridView4.DataSource = venderplant;
            GridView4.DataBind();
            vendorName.InnerText = venderplant[0].Vender_Name;
            LocalScriptManager.CreateScript(Page, "initVendorCodeList('" + serializedJson + "')", "vendorCodeList");
        }
    }
}