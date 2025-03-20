using AjaxMvc.Models;
using AjaxMvc.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AjaxMvc.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        
        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
           
                var user = new ApplicationUser
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    BirthDate = registerViewModel.BirthDate,
                    UserName = registerViewModel.EmailAdress,
                    Email = registerViewModel.EmailAdress
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.EmailAdress);
            
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
