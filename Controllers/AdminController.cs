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
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace Kidregs.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOptions<KidregsOptions> _options;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ISystemOptions _systemOptions;

        public AdminController(IOptions<KidregsOptions> options, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ISystemOptions systemOptions)
        {
            _options = options;
            _userManager = userManager;
            _signInManager = signInManager;
            _systemOptions = systemOptions;
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
        [ValidateAntiForgeryToken]
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
                await _signInManager.SignOutAsync();
            }

            if (DoLoginIn(login))
            {
                //登陆完成，重定向
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //登陆失败 回到登陆页面
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Reset()
        {
            ViewBag.SystemOptions = _systemOptions;
            return View();
        }

        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [ServiceFilter(typeof(reCaptchaValid))]
        [ValidateAntiForgeryToken]
        public IActionResult Reset(ResetViewModel reset)
        {
            if (reset.ResetCode == _options.Value.SuperPassword)
            {
                //通过校验，注册账号或重置密码
                var admin =  _userManager.FindByNameAsync("admin").Result;

                if (admin == null)
                {
                    var result = RegAdmin(reset.NewPassword);
                    if (!result.Succeeded)
                        return Content(result.Errors.First().Description);
                }
                else
                {
                    var result = ResetAdmin(admin,reset.NewPassword);
                    if (!result.Succeeded)
                        return Content(result.Errors.First().Description);
                }

                _signInManager.SignOutAsync();

                return RedirectToAction(nameof(Login));
            }
            else
            {
                //未通过校验，重定向至重置页面
                return RedirectToAction(nameof(reset));
            }
        }

        //登录逻辑
        private bool DoLoginIn(LoginViewModel login)
        {
            var user = _userManager.FindByNameAsync(login.Username).Result;

            if (user == null)
            {
                return false;
            }

            var result = _signInManager.PasswordSignInAsync(user, login.Password, login.Remember,false).Result;
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


        protected IdentityResult RegAdmin(string password)
        {
            var admin = new IdentityUser
            {
                UserName = "admin"
            };

            return _userManager.CreateAsync(admin, password).Result;
        }

        protected IdentityResult ResetAdmin(IdentityUser user, string password)
        {
            string code = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            return _userManager.ResetPasswordAsync(user, code, password).Result;
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
