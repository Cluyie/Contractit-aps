using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNamespace;

namespace ElmålingsSystem.MVC.Controllers
{
    [Route("maaler")]
    [Authorize]
    public class MålerController : Controller
    {
        private readonly IClient _clientService;
        public MålerController(IClient clientService)
        {
            _clientService = clientService;
        }

        [Route("maaler")]
        public async Task<IActionResult> MålerIndex(int installationsId)
        {
            TempData["installationsID"] = installationsId;
            var måler = await _clientService.GetMålerByInstallationsIdAsync(installationsId).ConfigureAwait(false);
            return View(måler);
        }
        [HttpGet]
        [Route("ny_maaler")]
        public IActionResult PostMåler(int installationsid)
        {
            TempData["PostInstallation"] = installationsid;
            return View();
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ny_maaler")]
        public async Task<IActionResult> PostMåler(MålerLinked måler)
        {
            var installationsId = TempData["PostInstallation"];
            await _clientService.PostMålerAsync(Convert.ToInt32(installationsId), måler).ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }


        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("slet_maaler")]
        public async Task<IActionResult> DeleteMåler(int dummy)
        {
            var installationsid = TempData["installationsID"];
            var model = await _clientService.GetMålerByInstallationsIdAsync(Convert.ToInt32(installationsid)).ConfigureAwait(false);
            TempData["SletMåler"] = model.MålerId;
            return View(model);
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [Route("slet_maaler")]
        public async Task<IActionResult> DeleteMåler()
        {
            var slet = TempData["SletMåler"];
            await _clientService.DeleteMålerByIdAsync(Convert.ToInt32(slet)).ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }
    }
}