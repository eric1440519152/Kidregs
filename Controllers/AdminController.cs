using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kidregs.Libraries.Class;
using Kidregs.Libraries.Interface;
using Kidregs.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Kidregs.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOptions<KidregsOptions> _options;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ISystemOptions _systemOptions;
        private readonly reCAPTCHA _reCaptcha;

        public AdminController(IOptions<KidregsOptions> options, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ISystemOptions systemOptions,reCAPTCHA reCaptcha)
        {
            _options = options;
            _userManager = userManager;
            _signInManager = signInManager;
            _systemOptions = systemOptions;
            _reCaptcha = reCaptcha;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard");
        }
        
        public IActionResult Login()
        {
            ViewBag.SystemOptions = _systemOptions;
            return View(GetLoginCookie());
        }

        [HttpPost]
        [ServiceFilter(typeof(reCaptchaValid))]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (login.Remember)
                //设置Cookie
                SetLoginCookie(login);
            else
            {
                //删除表单Cookie
                DelLoginCookie();
                //强制注销登录并清除用户管理器Cookie
                _signInManager.SignOutAsync();
            }

            if (await DoLoginIn(login))
                //登陆完成，重定向
                return RedirectToAction(nameof(Index));
            else
                //登陆失败 回到登陆页面
                return RedirectToAction(nameof(Login));
        }

        public IActionResult Reset()
        {
            return View();
        }

        //登录逻辑
        private async Task<bool> DoLoginIn(LoginViewModel login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);

            if (user == null)
                return false;

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.Remember,false);

            return result.Succeeded;
        }

        private void SetLoginCookie(LoginViewModel login)
        {
            var cryptUsername = SafeCrypto.Encrypt(login.Username);
            SetCookies("Username", cryptUsername, 2880);
            SetCookies("Remember", login.Remember.ToString(), 2880);
        }
        private LoginViewModel GetLoginCookie()
        {
            if (GetCookies("Username") == "")
                return null;

            return new LoginViewModel
            {
                Username = SafeCrypto.Decrypt(GetCookies("Username")),
                Remember = GetCookies("Remember") == "True" ? true : false
            };
        }

        protected void DelLoginCookie()
        {
            DeleteCookies("Username");
            DeleteCookies("Remember");
        }
        protected void SetCookies(string name, string value, int minutes = 30)
        {
            HttpContext.Response.Cookies.Append(name, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(minutes),
            });
        }

        protected void DeleteCookies(string name)
        {
            HttpContext.Response.Cookies.Delete(name);
        }

        protected string GetCookies(string name)
        {
            HttpContext.Request.Cookies.TryGetValue(name, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }

    }
}
