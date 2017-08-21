using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class FormWaitToFill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO::处理session过期问题,封装数据库操作到DAL层
            string sql = "select * from View_Multi_Vendor where Employee_ID='" + Session["Employee_ID"].ToString() + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = SelectEmployeeVendor_BLL.selectEmployeeVendor(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //row
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));

            //绑定session
            Session["tempvendorname"] = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            Session["tempVendorID"] = GridView1.Rows[drv.RowIndex].Cells[1].Text;

            if (e.CommandName == "showDetails")
            {
                As_Vendor_FormType Vendor_Form = new As_Vendor_FormType();
                //根据供应商类型编号查询所有未填写表格类型

                string sql = String.Format("SELECT * FROM View_Wait_MultiFill WHERE Employee_ID='{0}' and Temp_Vendor_ID='{1}'", Session["Employee_ID"].ToString(), Session["tempVendorID"].ToString());

                PagedDataSource objpds = new PagedDataSource();

                objpds.DataSource = SelectEmployeeVendor_BLL.listVendorFormType(sql);
                //获取数据源
                GridView2.DataSource = objpds;
                //绑定数据源
                GridView2.DataBind();
            }

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showDetails")
            {
                //获取供应商名称转换为临时ID的值传入session;
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string tempvendorname = GridView2.Rows[drv.RowIndex].Cells[2].Text;
                string formTypeID = e.CommandArgument.ToString();
                string tempVendorID = TempVendor_BLL.getTempVendorID(tempvendorname);
                Session["tempVendorID"] = tempVendorID;

                //点击不同表格进入到不同界面.
                switchPage(e.CommandArgument.ToString(), tempVendorID);
            }
        }

        private void switchPage(string commandArgument, string tempVendorID)
        {
            switch (commandArgument)
            {
                case "018":
                    Response.Redirect("VendorSelection.aspx?type=018");
                    break;
                default:
                    break;
            }
        }
    }
}