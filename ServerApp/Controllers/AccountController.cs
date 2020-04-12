using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController:Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }
        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            ViewBag.returnURL = returnURL;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel creds, string returnURL)
        {
            if (ModelState.IsValid)
            {
                if (await CheckLogin(creds))
                {
                    return RedirectToRoute(returnURL ?? "/");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or password");
                }
            }
            return View(creds);
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string redircetURL)
        {
            await signInManager.SignOutAsync();
            return Redirect(redircetURL ?? "/");
        }



        private async Task<bool> CheckLogin(LoginViewModel creds)
        {
            if (creds.Name == "admin" && creds.Password == "password")
            {
                 await signInManager.SignOutAsync();
                //Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(creds.UserName,creds.Password,false,false);
                return true;
            }

            return false;
        }
        [HttpPost("/api/account/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel creds)
        {
            if (ModelState.IsValid && await CheckLogin(creds))
            {
                return Ok("true");
            }
            return BadRequest();
        }

        [HttpPost("/api/account/logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

    }
}
