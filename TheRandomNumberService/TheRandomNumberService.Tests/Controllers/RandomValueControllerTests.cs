using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using TheRandomNumberService.Controllers;
using TheRandomNumberService.FakeDataAccess;

namespace TheRandomNumberService.Tests.Controllers
{
    [TestClass]
    public class RandomValueControllerTest
    {
        private RandomValueController controller;
        private IRandomNumberDataAccess randomNumberDataAccess;

        [TestInitialize]
        public void Initialize()
        {
            randomNumberDataAccess = A.Fake<IRandomNumberDataAccess>();

            controller = new RandomValueController(randomNumberDataAccess);
        }

        [TestMethod]
        public void Get()
        {
            A.CallTo(() => randomNumberDataAccess.GetAsync()).Returns(2);

            var result = controller.Get().Result as OkNegotiatedContentResult<int>;

            Assert.AreEqual(2, result.Content);
        }
    }
}
