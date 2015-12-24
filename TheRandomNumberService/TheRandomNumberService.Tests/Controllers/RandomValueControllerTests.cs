using Microsoft.VisualStudio.TestTools.UnitTesting;

using TheRandomNumberService.Controllers;

namespace TheRandomNumberService.Tests.Controllers
{
    [TestClass]
    public class RandomValueControllerTest
    {
        private RandomValueController controller;
        
        [TestInitialize]
        public void Initialize()
        {
            controller = new RandomValueController();
        }

        [TestMethod]
        public void Get()
        {
            var result = controller.Get().Result;

            Assert.AreEqual(2, result);
        }
    }
}
