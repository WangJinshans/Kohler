using Microsoft.VisualStudio.TestTools.UnitTesting;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SHZSZHSUPPLY.VendorAssess.Util.Tests
{
    [TestClass()]
    public class LocalApproveManagerTests
    {
        [TestMethod()]
        public void outPutPDFTest()
        {
            try
            {
                string url = "http://localhost:1668/VendorAssess/ShowVendorDiscovery.aspx?type=001&outPutID=VendorDiscovery_002053";
                string pdf = @"E:\wkhtmltopdf\bin\wkhtmltopdf.exe";

                Process process = new Process();
                process.StartInfo.FileName = pdf;
                process.StartInfo.Arguments = "--zoom 0.8 " + url + " \"" + @"E:\wkhtmltopdf\test\test1.pdf" + "\"";
                //Process p = Process.Start(pdf, url + " \"" + @"E:\wkhtmltopdf\test\test.pdf" + "\"");
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(ProcessExited);
                process.Start();
                if (!process.WaitForExit(15000)) //15s内必须退出
                {
                    process.Kill();
                    throw new Exception("TimeOut");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ProcessExited(object sender, EventArgs e)
        {
            Console.WriteLine(((Process)sender).ExitCode);      //0----success
        }
    }
}