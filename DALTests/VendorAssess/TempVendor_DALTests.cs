using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class TempVendor_DALTests
    {
        [TestMethod()]
        public void vendorNameExistTest()
        {
            TempVendor_DAL.vendorNameExist("819TestVendor");
        }
    }
}