using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UseRegisterrViewModel registerVm)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = registerVm.UserName;
                user.PhoneNumber = registerVm.PhoneNumber;
                user.Email = registerVm.Email;
                user.FirstName = registerVm.FirstName;
                user.LastName = registerVm.LastName;
                user.PasswordHash = registerVm.Password;
                user.Address = registerVm.Address;
                IdentityResult Result = await userManager.CreateAsync(user, registerVm.Password);
                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in Result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                    return View(registerVm);
                }
            }
            return View();
        }
        public async Task <IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        [HttpGet]
        public IActionResult LogIn(string returnUrl = null)
        {
            var model = new LoginInViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> LogIn(LoginInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
              ApplicationUser UserModel  = await userManager.FindByNameAsync(viewModel.UserName);
                if (UserModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(UserModel,viewModel.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(UserModel, viewModel.RememberMe);
                        if (!string.IsNullOrEmpty(viewModel.ReturnUrl) && Url.IsLocalUrl(viewModel.ReturnUrl))
                        {
                            return Redirect(viewModel.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "UserName Or Password InValid");
                }

            }
            return View(viewModel);
        }
    }
}
