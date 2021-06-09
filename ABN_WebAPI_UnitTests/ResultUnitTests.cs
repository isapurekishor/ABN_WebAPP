using ABN_WebAPI.Controllers;
using ABN_WebAPI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABN_WebAPI_UnitTests
{
    [TestClass]
    public class ResultUnitTests
    {
        [TestMethod]
        public void GetStatus_Result()
        {
            ResultController controller = new ResultController();
            ResultModel model = new ResultModel();
            
            model.Area = Convert.ToDecimal(78.5);
            model.Circumference = Convert.ToDecimal(31.4);
            model.Diameter = 10;
            model.Status = "Completed";
            model.Progress = 100;

            int radius = 5;
            var webAPIResult = controller.GetStatus(radius);
            Assert.AreEqual(model, webAPIResult);
        }
    }
}
