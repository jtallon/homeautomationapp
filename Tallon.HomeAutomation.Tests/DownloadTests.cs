using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Tallon.HomeAutomation.Helpers;

namespace Tallon.HomeAutomation.Tests
{
    [TestClass]
    public class DownloadTests
    {
        [TestMethod]
        public void HomeSensorTest()
        {
            var data = HomeSensorHelper.GetSensorData();
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Temperature > 0);
        }
    }
}
