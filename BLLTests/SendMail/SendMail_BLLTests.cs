using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.SendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.VendorAssess;

namespace BLL.SendMail.Tests
{
    [TestClass()]
    public class SendMail_BLLTests
    {
        [TestMethod()]
        public void SendMail_BLL_PlantTest()
        {
            SendMail_BLL sb = new SendMail_BLL();
            //Mail.Sendmail_BLL_Item("111111", "MSDS", "上海科勒", "TYpe", "hold", "TRUE", DateTime.Now.ToString(), DateTime.Now.ToString(), "ko12342", DateTime.Now.ToString(), "测试测试测试", "ko1421");
        }
    }
}