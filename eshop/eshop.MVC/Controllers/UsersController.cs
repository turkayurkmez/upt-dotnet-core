using eshop.Application.Services;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eshop.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string gidilecekSayfa)
        {
            ViewBag.ReturnUrl = gidilecekSayfa;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model, string? gidilecekSayfa)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role,user.Role)

                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        return Redirect(gidilecekSayfa);
                    }
                    return Redirect("/");
                }
                ModelState.AddModelError("login", "Kullanıcı adı ya da şifre yanlış");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");

        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
