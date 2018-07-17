using BLL;
using BLL.VendorAssess;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess.Html_Template
{
    public partial class Biddingformlists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool partone = true;
            bool parttwo = true;
            bool partthree = true;
            //初始化选择列表
            PagedDataSource source1 = new PagedDataSource();
            List<SelectionForm> biddings = As_Bidding_Approval_BLL.listApprovedBiddingform(Session["tempVendorID"].ToString(), Session["Factory_Name"].ToString());
            if (biddings.Count > 0)
            {
                source1.DataSource = biddings;
                GridView1.DataSource = source1;
                GridView1.DataBind();
                GridView1.SelectedIndex = 0;
            }
            else
            {
                GridView1.Visible = false;
                partone = false;
                //不存在任何已经审批成功的比价表
                LocalScriptManager.CreateScript(Page, "hide('1')", "hidearea1");
            }


            //PagedDataSource source2 = new PagedDataSource();
            //List<SelectionForm> zhidings = As_Bidding_Approval_BLL.listApprovedZhidingform(Session["tempVendorID"].ToString(), Session["Factory_Name"].ToString());
            //if (zhidings.Count > 0)
            //{
            //    source2.DataSource = zhidings;
            //    GridView2.DataSource = source2;
            //    GridView2.DataBind();
            //    GridView2.SelectedIndex = 0;
            //}
            //else
            //{
            //    GridView2.Visible = false;
            //    parttwo = false;
            //    //不存在任何已经审批成功的比价表
            //    LocalScriptManager.CreateScript(Page, "hide('2')", "hidearea2");
            //}



            //PagedDataSource source3 = new PagedDataSource();
            //List<SelectionForm> selections = As_Bidding_Approval_BLL.listApprovedSelectionform(Session["tempVendorID"].ToString(), Session["Factory_Name"].ToString());
            //if (selections.Count > 0)
            //{
            //    source3.DataSource = selections;
            //    GridView3.DataSource = source3;
            //    GridView3.DataBind();
            //    GridView3.SelectedIndex = 0;
            //}
            //else
            //{
            //    GridView3.Visible = false;
            //    partthree = false;

            //    //不存在任何已经审批成功的比价表
            //    LocalScriptManager.CreateScript(Page, "hide('3')", "hidearea3");
            //}
            //if (!partone && !parttwo && !partthree)
            //{
            //    LocalScriptManager.CreateScript(Page, "hidebtn()", "hidebtn");
            //}
            if (!partone && !parttwo && !partthree)
            {
                LocalScriptManager.CreateScript(Page, "hidebtn()", "hidebtn");
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string formID= Request.QueryString["formID"].ToString();


            //比价fileID
            int n1 = GridView1.SelectedRow.Cells[0].Text.ToString().IndexOf("T");
            string bidingFileID = GridView1.SelectedRow.Cells[0].Text.ToString().Substring(n1).Replace(".pdf", "");

            //如果没有绑定
            if (!ContractApproval_BLL.isBiddingBandOK(formID))
            {
                CheckFile_BLL.bindSingleFormFile(bidingFileID, Session["tempVendorID"].ToString(), formID);
                
                //编辑绑定成功
                ContractApproval_BLL.setBiddingBandOK(formID);
            }


            //关闭当前窗口
            LocalScriptManager.CreateScript(Page, "biddingSuccess()", "Success");
        }

        /// <summary>
        /// 供应商选择表的筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        //    ViewState["selection"] = GridView3.Rows[drv.RowIndex].Cells[0].Text;
        //}

        /// <summary>
        /// 指定供应商表的筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        //    ViewState["zhiding"] = GridView2.Rows[drv.RowIndex].Cells[0].Text;

        //}

        /// <summary>
        /// 供应商比价表的筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            ViewState["bidding"] = GridView1.Rows[drv.RowIndex].Cells[0].Text;
        }
    }
}