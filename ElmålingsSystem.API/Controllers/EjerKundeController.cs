using ElmålingsSystem.API.Infrastructure;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmålingsSystem.API.Controllers
{
    [Route("api/EjerKunde")]
    [ApiController]
    public class EjerKundeController : ControllerBase
    {
        private readonly IEjerKundeService _service;

        public EjerKundeController(IEjerKundeService service)
        {
            _service = service;
        }

        // GET /api/EjerKunde/{ejerKundeCprNr}
        [HttpGet("/{ejerKundeCprNr}", Name = nameof(GetEjerKunde))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<EjerKundeLinked>> GetEjerKunde(int ejerKundeCprNr)
        {
            var ejerKunde = await _service.GetEjerKundeByCpr(ejerKundeCprNr);

            if (ejerKunde == null) return NotFound();

            //return Ok(ejerKunde);
            return ejerKunde;
        }

        [HttpGet(Name = nameof(GetAllEjerKunder))]
        public async Task<ActionResult<IEnumerable<EjerKundeLinked>>> GetAllEjerKunder()
        {
            var ejerKunder = await _service.GetAllEjerKunder();

            var collection = new Collection<EjerKundeLinked>
            {
                Self = Link.ToCollection(nameof(GetAllEjerKunder)),
                Value = ejerKunder.ToArray()
            };

            return Ok(ejerKunder);
        }

        [HttpPost(Name = nameof(PostEjerKunde))]
        public async Task<ActionResult<EjerKundeLinked>> PostEjerKunde([FromBody] EjerKundeLinked ejerKunde)
        {
            var nyEjer = await _service.PostEjerKunde(ejerKunde);

            if (nyEjer == null) return NotFound();

            return Ok(nyEjer);
        }

        [HttpPut("{ejerKundeId}",Name = nameof(PutEjerKunde))]
        public async Task<ActionResult<EjerKundeLinked>> PutEjerKunde(int ejerKundeId, [FromBody]EjerKundeLinked ejerkunde)
        {
            var editedEjerKunde = await _service.PutEjerKundeById(ejerKundeId, ejerkunde);

            if (editedEjerKunde == null) return NotFound();

            return Ok(editedEjerKunde);
        }

        [HttpDelete("{ejerKundeCprNr}",Name = nameof(DeleteEjerKunde))]
        public async Task<ActionResult<EjerKundeLinked>> DeleteEjerKunde(int ejerKundeCprNr)
        {
            var ejer = await _service.DeleteEjerKundeByCpr(ejerKundeCprNr);

            if (ejer == false) return NotFound();

            return Ok();
        }
    }
}