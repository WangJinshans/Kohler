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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            QT_SCAR newSCAR = new QT_SCAR();
            newSCAR.Factory = Session["Factory_Name"].ToString();
            
            //获取值
            newSCAR.Batch_No = TextBox1.Text;
            newSCAR.Vendor_Code = TextBox2.Text;

            //原因 发生影响产品质量的重大问题  发生重大客户投诉  管理者认为需要书面纠正预防的其它问题
            newSCAR.Reason = reason.Text.Trim();

            newSCAR.Flag = 0;

            //判断是否存在
            if (SCAR_BLL.haveSCAR(TextBox1.Text, TextBox2.Text))
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