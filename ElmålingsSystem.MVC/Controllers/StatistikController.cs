using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNamespace;

namespace ElmålingsSystem.MVC.Controllers
{
    [Route("statistik")]
    [Authorize]
    public class StatistikController : Controller
    {
        private readonly IClient _clientService;
        public StatistikController(IClient clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("statistik_mellem_to_datoer")]
        public async Task<IActionResult> StatistikIndex(int målerid, DateTime? start, DateTime? slut)
        {
           
            TempData["målerId"] = målerid;
            if (!start.HasValue)
            {
                start = DateTime.Now.AddMonths(-1);
                slut = DateTime.Now;

            }
            var statistik = await _clientService.GetAllMåleVærdierFromMålerIdAndDateAsync(målerid, start, slut).ConfigureAwait(false);
            return View(statistik);
        }

        [HttpPost]
        [Route("statistik_mellem_to_datoer")]
        public async Task<IActionResult> StatistikIndex(DateTime start, DateTime slut)
        {
            int måler = Convert.ToInt32(TempData["målerId"]);
            await _clientService.GetAllMåleVærdierFromMålerIdAndDateAsync(måler, start, slut);
            return await StatistikIndex(måler, start, slut);
            
        }
    }
}