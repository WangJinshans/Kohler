using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BLL.QualityDetection;
using MODEL.QualityDetection;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class SCAR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSessionInfo();
                initScar();
            }
        }

        private void getSessionInfo()
        {
            //获取检验批
            ViewState.Add("batch_No", Request.QueryString["batch_No"]);
        }

        /// <summary>
        /// 初始化最前面的几个数据
        /// </summary>
        protected void initScar()
        {
            string batch_No = Convert.ToString(ViewState["batch_No"]);

            //获取数据  初始化前面几个数据

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }

    }
}