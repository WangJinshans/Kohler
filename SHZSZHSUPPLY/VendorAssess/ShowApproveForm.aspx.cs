using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class ShowApproveForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO::sql中添加factory
            string sql = "select * from View_Approve_Top where Position_Name='" + Session["Position_Name"].ToString() + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = SelectApproveForm_BLL.selectApproveForm(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "showDetails")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));

                Session["formid"] = GridView1.Rows[drv.RowIndex].Cells[0].Text;
                string formname = GridView1.Rows[drv.RowIndex].Cells[1].Text;//获取点击的那张表的名称

                //根据名称进入不同的页面
                switchShowPage(formname);
            }
        }

        private void switchShowPage(string formName)
        {
            switch (formName)
            {
                case "供应商调查表":
                    Response.Redirect("ShowVendorDiscovery.aspx");
                    break;
                case "供应商风险分析表":
                    Response.Redirect("ShowVendorRiskAnalysis.aspx");
                    break;
                case "指定供应商申请表":
                    Response.Redirect("ShowVendorDesignatedApply.aspx");
                    break;
                case "合同审批表":
                    Response.Redirect("ShowContractApprovalForm.aspx");
                    break;
                case "供应商选择表":
                    Response.Redirect("ShowVendorSelection.aspx");
                    break;
                case "供应商信息表(建立)":
                    Response.Redirect("ShowVendorCreation.aspx");
                    break;
                case "供应商信息表(修改)":
                    Response.Redirect("ShowVendorCreation.aspx");
                    break;
                case "供应商信息表(恢复/删除/block)":
                    Response.Redirect("ShowVendorBlockOrUnBlock.aspx");
                    break;
                case "供应商信息表(扩展)":
                    Response.Redirect("ShowVendorExtend.aspx");
                    break;
                case "价格调整审批":
                    break;
                default:
                    break;
            }
        }
    }
}