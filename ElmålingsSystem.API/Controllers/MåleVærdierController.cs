using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmålingsSystem.API.Infrastructure;
using ElmålingsSystem.API.Services;
using ElmålingsSystem.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElmålingsSystem.API.Controllers
{
    [Route("api/Måleværdier")]
    [ApiController]
    public class MåleVærdierController : ControllerBase
    {
        private readonly IMåleVærdierService _service;

        public MåleVærdierController(IMåleVærdierService service)
        {
            _service = service;
        }

        [HttpGet("{målerId}", Name = nameof(GetAllMåleVærdierFromMålerIdAndDate))]
        public async Task<ActionResult<IEnumerable<MåleVærdierLinked>>> GetAllMåleVærdierFromMålerIdAndDate(int målerId, DateTime start, DateTime end)
        {
           
            var måleVærdier = await _service.GetAllMåleVærdierFromMålerIdAndDate(målerId, start, end);

            if (måleVærdier == null) return NotFound();

            var collection = new Collection<MåleVærdierLinked>
            {
                Self = Link.ToCollection(nameof(GetAllMåleVærdierFromMålerIdAndDate)),
                Value = måleVærdier.ToArray()
            };

            return Ok(måleVærdier);
        }
    }
}