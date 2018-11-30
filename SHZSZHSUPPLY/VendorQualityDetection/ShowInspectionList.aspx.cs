using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.QualityDetection;
using System.Data.SqlClient;
using Model;
using System.Data;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
	public partial class ShowInspectionList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ScriptManager1.RegisterAsyncPostBackControl(this.dropStatus);
			if (!IsPostBack)
			{
				
			}
			else
			{
				//string time = Request.Form["time1"];
				//getListbyTime(time);
				switch (Request["__EVENTTARGET"])
				{
					
					case "timeSelect":
						{
							Session["time"] = Request.Form["__EVENTARGUMENT"];
							string time = Session["time"].ToString();
							getListbyTime(time);
							
							break;
						}

					default:
						break;
				}


			}

		}
		protected DataTable getList(string time)
		{
			DataTable itemList;
			itemList = InspectionList_BLL.selectListItem(time);
			return itemList;
		}

		protected void getListbyTime(string time)
		{
			DataTable itemList = getList(time);
			if (itemList.Rows.Count != 0)
			{
				GridView1.DataSource = itemList.DefaultView;
				GridView1.DataBind();
			}
		}

		

		protected void getListbyStatus(string time,string status)
		{
			DataTable newdt = new DataTable();
			
			DataTable itemList = getList(time);
			newdt = itemList.Clone();
			DataRow[] drs = itemList.Select("Status = '" + status + "'");
			foreach(DataRow dr in drs){
				newdt.Rows.Add(dr.ItemArray);
			}
			if (newdt.Rows.Count != 0)
			{
				GridView1.DataSource = newdt.DefaultView;
				GridView1.DataBind();
			}



		}

		protected void dropStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
            string time = "";
            try
            {
                time = Session["time"].ToString();
            }
            catch
            {
                LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')","请先选择时间"), "timeTip");
            }


            string status = dropStatus.SelectedItem.Text;
			getListbyStatus(time, status);
		}
	}
}