using ElmålingsSystem.API.Infrastructure;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmålingsSystem.API.Controllers
{
    [Route("api/Installation")]
    [ApiController]
    public class InstallationController : ControllerBase
    {
        private readonly IInstallationService _service;

        public InstallationController(IInstallationService service)
        {
            _service = service;
        }

        [HttpGet("{installationsId}", Name = nameof(GetInstallation))]
        public async Task<ActionResult<InstallationDTO>> GetInstallation(int installationsId)
        {
            var installation = await _service.GetInstallationById(installationsId);

            if (installation == null) return NotFound();

            return Ok(installation);
        }

        [HttpGet("All/{ejerKundeCprNr}", Name = nameof(GetAllInstallationer))]
        public async Task<ActionResult<IEnumerable<InstallationDTO>>> GetAllInstallationer(int ejerKundeCprNr)
        {
            var installationer = await _service.GetAllInstallationerFromKundeCprNr(ejerKundeCprNr);

            if (installationer == null) return NotFound();

            var collection = new Collection<InstallationDTO>
            {
                Self = Link.ToCollection(nameof(GetAllInstallationer)),
                Value = installationer.ToArray()
            };

            return Ok(installationer);
        }

        [HttpPost(Name = nameof(PostInstallation))]
        public async Task<ActionResult<InstallationDTO>> PostInstallation(int ejerKundeCprNr, [FromBody] InstallationDTO installation)
        {
            var nyInstallation = await _service.PostInstallation(ejerKundeCprNr, installation);

            if (nyInstallation == null) return NotFound();

            return Ok(nyInstallation);
        }

        [HttpPut("{installationsId}",Name = nameof(PutInstallation))]
        public async Task<ActionResult<InstallationDTO>> PutInstallation(int installationsId, [FromBody]InstallationDTO installation)
        {
            var editedInstallation = await _service.PutInstallationById(installationsId, installation);

            if (editedInstallation == null) return NotFound();

            return Ok(editedInstallation);
        }

        [HttpDelete("{installationsId}",Name = nameof(DeleteInstallation))]
        public async Task<ActionResult<InstallationDTO>> DeleteInstallation(int installationsId)
        {
            var installation = await _service.DeleteInstallationById(installationsId);

            if (installation == false) return NotFound();

            return Ok();
        }
    }
}