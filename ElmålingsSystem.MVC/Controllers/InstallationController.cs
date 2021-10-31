using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNamespace;

namespace ElmålingsSystem.MVC.Controllers
{
    [Route("installation")]
    [Authorize]
    public class InstallationController : Controller
    {
        private readonly IClient _clientService;
        public InstallationController(IClient clientService)
        {
            _clientService = clientService;
        }

        [Route("alle_installationer")]
        public async Task<IActionResult> Index(int cprNr)
        {
            var installation = await _clientService.GetAllInstallationerAsync(cprNr).ConfigureAwait(false);
            return View(installation);
        }

        [Route("installation")]
        public async Task <IActionResult> InstallationIndex(int installationsId)
        {
            var installation = await _clientService.GetInstallationAsync(installationsId).ConfigureAwait(false);
            return View(installation);
        }

        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("ny_installation")]
        public IActionResult PostInstallation(int cprnr)
        {
            TempData["cprnr"] = cprnr;
            return View();
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ny_installation")]
        public async Task<IActionResult> PostInstallation(InstallationLinked installation)
        {
            var s = TempData["cprnr"];
            await _clientService.PostInstallationAsync(Convert.ToInt32(s), installation).ConfigureAwait(false);
            return RedirectToAction("Index", "Kunde");
        }

        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("redigere_installation")]
        public async Task<IActionResult> PutInstallation(int InstallationsId)
        {
            TempData["installationsid"] = InstallationsId;
            var installation = await _clientService.GetInstallationAsync(InstallationsId).ConfigureAwait(false);
            return View(installation);
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("redigere_installation")]
        public async Task<IActionResult> PutInstallation(InstallationLinked installation)
        {
            var s = TempData["installationsid"];
            await _clientService.PutInstallationAsync(Convert.ToInt32(s), installation).ConfigureAwait(false);
            return RedirectToAction("Index", "Kunde");
        }

        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("slet_installation")]
        public async Task<IActionResult> DeleteInstallation(int installationsId, int dummy)
        {
            TempData["Sletinstallationsid"] = installationsId;
            var installation = await _clientService.GetInstallationAsync(installationsId).ConfigureAwait(false);
            return View(installation);
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [Route("slet_installation")]
        public async Task<IActionResult> DeleteInstallation(int cprnr)
        {
            var slet = TempData["Sletinstallationsid"];
            await _clientService.DeleteInstallationAsync(Convert.ToInt32(slet)).ConfigureAwait(false);
            return RedirectToAction("Index", "Kunde");
        }
    }
}