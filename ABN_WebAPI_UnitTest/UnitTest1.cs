using ABN_WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABN_WebAPI_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int radius = 5;
            var controller = new AreaController();
            var result = controller.StartCalculation(radius);
            Assert.AreEqual(78.5, result.Area);

        }
    }
}
