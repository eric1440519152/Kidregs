using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kidregs.Libraries.Class;
using Kidregs.Libraries.Interface;
using Microsoft.AspNetCore.Authorization;
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

        public AdminController(IOptions<KidregsOptions> options,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,ISystemOptions systemOptions)
        {
            _options = options;
            _userManager = userManager;
            _signInManager = signInManager;
            _systemOptions = systemOptions;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Index","Dashboard");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Reset()
        {
            return View();
        }
    }
}
