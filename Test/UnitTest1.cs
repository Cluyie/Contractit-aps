using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class MockingHttpContextTest
    {
        private HttpContextBase rmContext;
        private HttpRequestBase rmRequest;
        private Mock<HttpContextBase> moqContext;
        private Mock<HttpRequestBase> moqRequest;
        [TestInitialize]
        public void SetupTests()
        {
            // Setup Rhino Mocks
            rmContext = MockRepository.GenerateMock<HttpContextBase>();
            rmRequest = MockRepository.GenerateMock<HttpRequestBase>();
            rmContext.Stub(x => x.Request).Return(rmRequest);
            // Setup Moq
            moqContext = new Mock<HttpContextBase>();
            moqRequest = new Mock<HttpRequestBase>();
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);
        }
    }
