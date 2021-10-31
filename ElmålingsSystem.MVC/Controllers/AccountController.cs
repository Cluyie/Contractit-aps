using System.Linq;
using System.Threading.Tasks;
using ElmålingsSystem.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElmålingsSystem.MVC.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;        
        private readonly RoleManager<IdentityRole> _roleManager;



        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
           
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.BrugerLogin.ToString());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        [Route("logout")]
        public async Task <IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize("Medarbejder")]
        [HttpGet]
        [Route("registrere")]

        public IActionResult Registrere()
        {
            var roller = _roleManager.Roles.ToList();
            return View(new RegistrereViewModel { Roller = roller });
        }

        [Authorize("Medarbejder")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("registrere")]
        public async Task<IActionResult> Registrere(RegistrereViewModel model) // 
        {

            var role = _roleManager.FindByIdAsync(model.Name).Result;

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.BrugerLogin.ToString(), Id = model.BrugerLogin.ToString() };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   await _userManager.AddToRoleAsync(user, role.Name);
                                                          
                    model.Roller = _roleManager.Roles.ToList();
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
           

        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("login");
                }

                // ChangePasswordAsync ændrer brugerens password
                var result = await _userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // ved succesfuld ændring af password vil sign-in cookien blive opdateret
                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }
    }
}