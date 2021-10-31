using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElmålingsSystem.MVC.Controllers
{
    [Route("roller")]
    [Authorize("Medarbejder")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Route("se_alle_roller")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [Route("ny_rolle")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        [Route("ny_rolle")]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}