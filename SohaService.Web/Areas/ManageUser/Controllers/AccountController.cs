using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SohaService.Core.DTOs.User;
using SohaService.Core.Services.Interfaces;

namespace SohaService.Web.Areas.ManageUser.Controllers
{
    [Area("ManageUser")]
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #region Login

        [Route("Login")]
        public IActionResult Login(bool EditProfile = false, string ReturnUrl = "/")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.EditProfile = EditProfile;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            string ReturnUrl = login.ReturnUrl;

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;

                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ReturnUrl = "/";
                            return Redirect(ReturnUrl);
                    }

#pragma warning disable CS0162 // Unreachable code detected
                    return View();
#pragma warning restore CS0162 // Unreachable code detected
                }
                else
                {
                    ModelState.AddModelError("UserName", "حساب کاربری شما فعال نمی باشد");
                }
            }
            ModelState.AddModelError("UserName", "کاربری با این مشخصات یافت نشد");
            return View(login);


        }

        #endregion

        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion
    }
}
