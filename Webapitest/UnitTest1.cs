using ElmålingsSystem.API.Controllers;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.MVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyNamespace;
using System;
using Xunit;

namespace Webapitest
{
    
    public class UnitTest1
    {
        private readonly Mock<IClient> _mockrepo;
        private readonly KundeController _Controller;

        public UnitTest1 ()
        {
            _mockrepo = new Mock<IClient>();
            _Controller = new KundeController(_mockrepo.Object);
        }



        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            _Controller.ModelState.AddModelError("Name", "Name is required");

            var ejerkunde = new MyNamespace.EjerKundeLinked { ForNavn = "hans", EfterNavn = "Jørgen" };

            var result = _Controller.PostEjerKunde(ejerkunde);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testEmployee = Assert.IsType<MyNamespace.EjerKundeLinked>(viewResult.Model);
            Assert.Equal(ejerkunde.ForNavn, testEmployee.ForNavn);
            Assert.Equal(ejerkunde.EfterNavn, testEmployee.EfterNavn);
        }
    }
}
