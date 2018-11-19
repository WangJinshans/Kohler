using BLL;
using BLL.QualityDetection;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class ScareList : System.Web.UI.Page
    {
        public Dictionary<string, Dictionary<string, string[]>> info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                info = TempVendor_BLL.readVendorInFactory(Convert.ToString(Session["Factory_Name"]));
                JavaScriptSerializer jss = new JavaScriptSerializer();

                string result = jss.Serialize(info[Session["Factory_Name"].ToString()]);
                LocalScriptManager.CreateScript(Page, String.Format("setParam('{0}')", result), "setParameter");
            }

            else
            {
                switch (Request.Form["__EVENTTARGET"])
                {
                    case "loadInfo":
                        initGridView(Request.Form["__EVENTARGUMENT"]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void initGridView(string tempVendorID)
        {
            //获取该供应商的所有检验批
            string vendorCode = TempVendor_BLL.getNormalCode(tempVendorID);
            string factory = Session["Factory_Name"].ToString();

            //从退货列表中获取
            GridView1.DataSource = GoodsReturned_BLL.getReturnList(vendorCode, factory);
            GridView1.DataBind();

            LocalScriptManager.CreateScript(Page, "reSetParam()", "reSetParameter");

            
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
                DropDownList reason = this.GridView1.Rows[drv.RowIndex].Cells[4].FindControl("DropDownList1") as DropDownList;
                newSCAR.Reason = reason.SelectedValue;
                newSCAR.Flag = 0;

                //判断是否存在Scar 
                if (SCAR_BLL.haveSCAR(batch_No, vendor_Code))
                {
                    LocalScriptManager.CreateScript(Page, String.Format("mytips('{0}')", "该供应商的该批次已触发SCAR"), "scarTip");
                    return;
                }



                //下载文件？
                int n = SCAR_BLL.addSCAR(newSCAR);
                if (n == 0)
                {
                    Response.Write("<script>window.alert('手动触发Scar成功')</script>");
                    return;
                }
                string formID = SCAR_BLL.getSCARFormID(newSCAR);



                //跳转到SCAR页面
                Response.Redirect("SCAR.aspx?form_ID=" + formID);
            }

           
        }
    }
}