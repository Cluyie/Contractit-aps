using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNamespace;

namespace ElmålingsSystem.MVC.Controllers
{
    [Route("ejer")]
    [Authorize("EjerMedarbejder")] 
    public class KundeController : Controller
    {
        private readonly IClient _clientService;
        public KundeController(IClient clientService)
        {
            _clientService = clientService;
        }

        [Route("ejer")]
        public async Task <IActionResult> EjerkundeIndex(int cprnr)
        {
            
            var ejerkunde = await _clientService.GetEjerKundeAsync(cprnr).ConfigureAwait(false);
            return View(ejerkunde);
        }
        [Route("ejerer")]
        public async Task<IActionResult> Index()
        {
            var ejerkunder = await _clientService.GetAllEjerKunderAsync().ConfigureAwait(false);
            return View(ejerkunder);
            
        }

        [Authorize("Medarbejder")]
        [HttpGet]        
        [Route("ny_ejer")]
        public IActionResult PostEjerKunde()
        {
            return View();
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ny_ejer")]
        public async Task <IActionResult> PostEjerKunde(EjerKundeLinked ejerkunde)
        {
            await _clientService.PostEjerKundeAsync(ejerkunde).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        [Route("redigere_ejer")]
        public async Task <IActionResult> PutEjerKunde(int cprnr)
        {
            
            var model = await _clientService.GetEjerKundeAsync(cprnr).ConfigureAwait(false);
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("redigere_ejer")]
        public async Task <IActionResult> PutEjerKunde(EjerKundeLinked ejerKunde)
        {
            await _clientService.PutEjerKundeAsync(ejerKunde.KundeId, ejerKunde).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("slet_ejer")]
        public async Task<IActionResult> DeleteEjerKunde(int cprnr,int dummy)
        {
            var model = await _clientService.GetEjerKundeAsync(cprnr).ConfigureAwait(false);
            return View(model);
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [Route("slet_ejer")]
        public async Task<IActionResult> DeleteEjerKunde(int cprnr)
        {
            await _clientService.DeleteEjerKundeAsync(cprnr).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}