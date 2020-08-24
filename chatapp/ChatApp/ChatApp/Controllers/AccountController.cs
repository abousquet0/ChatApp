using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Data;
using ChatApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class AccountController : Controller
    {
        IRepositoryWrapper _repositoryWrapper;

        private UserManager<IdentityUser> _gUser;
        private IUserValidator<IdentityUser> _vUser;
        private IPasswordValidator<IdentityUser> _vPassword;
        private IPasswordHasher<IdentityUser> _hPassword;
        private RoleManager<IdentityRole> _gRole;
        private SignInManager<IdentityUser> _gSignInManager;
        public AccountController(IRepositoryWrapper repositoryWrapper,
                UserManager<IdentityUser> p_gU,
                IUserValidator<IdentityUser> p_vU,
                IPasswordValidator<IdentityUser> p_vPassword,
                IPasswordHasher<IdentityUser> p_hPassword,
                RoleManager<IdentityRole> p_gr,
                SignInManager<IdentityUser> p_gSignInManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _gUser = p_gU;
            _vUser = p_vU;
            _vPassword = p_vPassword;
            _hPassword = p_hPassword;
            _gRole = p_gr;
            _gSignInManager = p_gSignInManager;
        }
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginPost(LoginModel loginModel)
        {
            IdentityUser user = await _gUser.FindByNameAsync(loginModel.UserName);

            if (user != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await _gSignInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("InvalidLogin", "Invalid username or password.");
            }
            return View(new LoginModel());
        }

        public IActionResult CreateAccount()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ActionName("CreateAccount")]
        public async Task<IActionResult> CreateAccountPost(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser()
                {
                    UserName = model.UserName
                };
                IdentityResult identityResult = await _gUser.CreateAsync(identityUser, model.Password);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (IdentityError erreur in identityResult.Errors)
                    {
                        ModelState.AddModelError("", erreur.Description);
                    }
                }
            }
            return View(new LoginModel());
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _gSignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}