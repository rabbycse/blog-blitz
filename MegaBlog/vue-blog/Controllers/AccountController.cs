using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace vue_blog.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if ((await _signInManager.PasswordSignInAsync(username,password, false, false)).Succeeded)
           {
               return RedirectToAction("Index", "BlogAdmin");
           }
           return RedirectToAction("Login", "Account");
        }
    }
}