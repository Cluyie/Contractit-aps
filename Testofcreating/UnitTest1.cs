using ElmålingsSystem.API.Services;
using ElmålingsSystem.MVC.Controllers;
using GenFu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyNamespace;
using System.Collections.Generic;
using System.Linq;

namespace Testofcreating
{
    [TestClass]
    public class HomeControllerTest
    {
        
        private IEnumerable<EjerKundeLinked> GetFakeData()
        {
            var i = 1;
            var ejerkunde = A.ListOf<EjerKundeLinked>(26);
            ejerkunde.ForEach(x => x.KundeId = i++);
            return ejerkunde.Select(_ => _);
        }
        [TestMethod]
        public void GetPersonsTest()
        {
            // arrange
            var service = new Mock<DefaultEjerKundeService>();

            var persons = GetFakeData();
            service.Setup(x => x.AllPersons()).Returns(persons);

            var controller = new PersonController(service.Object);

            // Act
            var results = controller.GetPersons();

            var count = results.Count();

            // Assert
            Assert.Equal(count, 26);
        }
    }
}
