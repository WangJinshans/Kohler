using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SHZSZHSUPPLY
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            this.BeginRequest += new EventHandler(Application_BeginRequest);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                if (exception is HttpUnhandledException && Session["Employee_Name"]==null)
                {
                    Response.Write("<script>window.alert('登录已过期，请重新登录系统！');window.location.href='../Login.aspx'</script>");
                    Server.ClearError();
                }
                else if (exception.InnerException.Message.Contains("插入重复键") || exception.InnerException.Message.Contains("冲突"))
                {
                    Response.Write("<script>window.alert('此动作已执行，请勿重复！');window.location.href='./VendorAssess/EmployeeVendor.aspx'</script>");
                    Server.ClearError();
                }
            }
            
        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            Console.WriteLine("new Session..........................");
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

            //TODO::session结束后清理临时文件 2017年11月29日21:42:27
            Thread thread = new Thread(new ParameterizedThreadStart((o) => {
                FileInfo file = new FileInfo(o.ToString());
                if (file.Exists)
                {
                    file.Delete();
                }
            }));
            thread.Start(System.Web.Hosting.HostingEnvironment.MapPath(Properties.Settings.Default.Transfer_Temp_Path) + Session.SessionID + ".pdf");
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            string oldUrl = HttpContext.Current.Request.RawUrl;
        }

    }
}
