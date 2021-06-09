using ABN_WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABN_WebAPI_UnitTests
{
    [TestClass]
    public class AreaUnitTests
    {
        [TestMethod]
        public void GetStatus_Area()
        {
            AreaController controller = new AreaController();
            int radius = 5;
            double testArea = 78.5;
            var webAPIResult = controller.StartCalculation(radius);
            Assert.AreEqual(testArea, webAPIResult.Area);
        }

        [TestMethod]
        public void GetStatus_Diameter()
        {
            AreaController controller = new AreaController();
            int radius = 5;
            double testDiameter = 10;
            var webAPIResult = controller.StartCalculation(radius);
            Assert.AreEqual(testDiameter, webAPIResult.Diameter);
        }

        [TestMethod]
        public void GetStatus_Circumference()
        {
            AreaController controller = new AreaController();
            int radius = 5;
            double testCircumference = 31.4;
            var webAPIResult = controller.StartCalculation(radius);
            Assert.AreEqual(testCircumference, webAPIResult.Circumference);
        }
    }
}
