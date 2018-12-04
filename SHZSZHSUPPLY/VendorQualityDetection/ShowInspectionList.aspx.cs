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
							//Response.Write("<script>$('#test1').text('"+ time +"');</script>");
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
				Response.Write("<script>window.alert('请先填写时间!')</script>");
			}

			
            string status = dropStatus.SelectedItem.Text;
			if (status == "全部")
			{
				getListbyTime(time);
			}
			else
			{
				getListbyStatus(time, status);
			}

			UpdatePanel1.Update(); //异步刷新页面
		}
	}
}