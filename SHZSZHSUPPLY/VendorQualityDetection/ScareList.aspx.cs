using BLL.QualityDetection;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class ScareList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取所有的供应商 类型 名称 初始化两个下拉列表
        }


        /// <summary>
        /// 手动触发单个检验批Scar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string batch_No = GridView1.Rows[drv.RowIndex].Cells[2].Text;
            string vendor_Code = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            if (e.CommandName.Equals("triggerScar"))
            {
                QT_SCAR newSCAR = new QT_SCAR();
                newSCAR.Factory = Session["Factory_Name"].ToString();

                //获取值
                newSCAR.Batch_No = batch_No;
                newSCAR.Vendor_Code = vendor_Code;

                //原因 发生影响产品质量的重大问题  发生重大客户投诉  管理者认为需要书面纠正预防的其它问题

                //获取原因 
                DropDownList reason = (DropDownList)this.GridView1.Rows[drv.RowIndex].FindControl("DropDownList");

                newSCAR.Reason = reason.SelectedValue;

                newSCAR.Flag = 0;

                //判断是否存在Scar 
                if (SCAR_BLL.haveSCAR(batch_No, vendor_Code))
                {
                    LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "该供应商的该批次已触发SCAR"), "scarTip");
                    return;
                }

                int n = SCAR_BLL.addSCAR(newSCAR);
                if (n == 0)
                {
                    Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                    return;
                }
                string formID = SCAR_BLL.getSCARFormID(newSCAR);



                //跳转到SCAR页面
                Response.Redirect("SCAR.aspx?form_ID=" + formID);
            }

           
        }
    }
}