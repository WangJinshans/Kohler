using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CancelFormControlEnterKey(this.Page.Form.Controls);
        }
        /// <summary>
        /// 在这里我们给Form中的服务器控件添加客户端onkeydown脚步事件，防止服务器控件按下enter键直接回发
        /// </summary>
        /// <param name="controls"></param>
        public static void CancelFormControlEnterKey(ControlCollection controls)
        {
            foreach (Control item in controls)
            {
                //服务器TextBox
                if (item.GetType() == typeof(System.Web.UI.WebControls.TextBox))
                {
                    WebControl webControl = item as WebControl;
                    webControl.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {return false;}} ");
                }
                //html控件
                else if (item.GetType() == typeof(System.Web.UI.HtmlControls.HtmlInputText))
                {
                    HtmlInputControl htmlControl = item as HtmlInputControl;
                    htmlControl.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {return false;}} ");
                }
                //用户控件
                else if (item is System.Web.UI.UserControl)
                {
                    CancelFormControlEnterKey(item.Controls); //递归调用
                }
            }
        }
    }
}