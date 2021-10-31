using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNamespace;

namespace ElmålingsSystem.MVC.Controllers
{
    [Route("lejer")]
    [Authorize("LejerMedarbejder")]
    public class LejerKundeController : Controller
    {
        private readonly IClient _clientService;
        public LejerKundeController(IClient clientService)
        {
            _clientService = clientService;
        }

        [Route("lejer")]
        public async Task<IActionResult> LejerkundeIndex(int cprnr)
        {
            var lejerkunde = await _clientService.GetLejerKundeByIdAsync(cprnr).ConfigureAwait(false);
            return View(lejerkunde);
        }

        [Route("lejerer")]
        public async Task<IActionResult> Index()
        {
            var lejerkunder = await _clientService.GetAllLejerKunderAsync().ConfigureAwait(false);
            return View(lejerkunder);

        }

        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("ny_lejer")]
        public IActionResult PostLejerKunde(int installationsid)
        {
            TempData["PostInstallation"] = installationsid;
            return View();
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ny_lejer")]
        public async Task<IActionResult> PostLejerKunde(LejerKundeLinked lejerkunde)
        {
            var installationsId = TempData["PostInstallation"];
            await _clientService.PostLejerKundeAsync(Convert.ToInt32(installationsId), lejerkunde).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [Authorize("LejerMedarbejder")]
        [HttpGet]
        [Route("redigere_lejer")]
        public async Task<IActionResult> PutLejerKunde(int cprnr)
        {
            var model = await _clientService.GetLejerKundeByIdAsync(cprnr).ConfigureAwait(false);
            TempData["LejerId"] = model.KundeId;
            return View(model);
        }

        [Authorize("LejerMedarbejder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("redigere_lejer")]
        public async Task<IActionResult> PutLejerKunde(LejerKundeLinked lejerKunde)
        {
            var putLejer = TempData["LejerId"];
            await _clientService.PutLejerKundeByIdAsync(Convert.ToInt32(putLejer), lejerKunde).ConfigureAwait(false);
            return RedirectToAction("Index", "Home");

        }

        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("slet_lejer")]
        public async Task<IActionResult> DeleteLejerKunde(int cprnr, int dummy)
        {
            TempData["SletLejer"] = cprnr;
            var model = await _clientService.GetLejerKundeByIdAsync(cprnr).ConfigureAwait(false);
            return View(model);
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [Route("slet_lejer")]
        public async Task<IActionResult> DeleteLejerKunde(int cprnr)
        {
            var slet = TempData["SletLejer"];
            await _clientService.DeleteLejerKundeByIdAsync(Convert.ToInt32(slet)).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}