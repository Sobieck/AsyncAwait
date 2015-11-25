using Microsoft.VisualStudio.TestTools.UnitTesting;

using TheRandomNumberService.Controllers;

namespace TheRandomNumberService.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            var controller = new ValuesController();

            var result = controller.Get().Result;

            Assert.AreEqual(2, result);
        }
    }
}
