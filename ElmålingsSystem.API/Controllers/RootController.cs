using ElmålingsSystem.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ElmålingsSystem.API.Controllers
{
    [Route("/api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new RootResponse
            {
                Self = Link.To(nameof(GetRoot)),
                EjerKunder = Link.ToCollection(nameof(EjerKundeController.GetAllEjerKunder)),
                Installationer = Link.ToCollection(nameof(InstallationController.GetAllInstallationer))
            };

            return Ok(response);
        }
    }
}
