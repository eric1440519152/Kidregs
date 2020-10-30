using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EasyOffice.Interfaces;
using Kidregs.Libraries.Class;
using Kidregs.Libraries.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kidregs.Models;
using Kidregs.ViewModels.Dashboard;
using Kidregs.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;

namespace Kidregs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KidregsContext _kidregsContext;
        private readonly ISystemOptions _systemOptions;

        public HomeController(ILogger<HomeController> logger,KidregsContext kidregsContext,ISystemOptions systemOptions)
        {
            _logger = logger;
            _kidregsContext = kidregsContext;
            _systemOptions = systemOptions;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");
            else
                return RedirectToAction("Reg");
        }
        
        public IActionResult Reg(RegViewModel regView)
        {
            var nationLists = _kidregsContext.NationList.ToList();

            ViewBag.nationLists = nationLists;
            ViewBag.SystemOptions = _systemOptions;

            if (!_systemOptions.RegSwitch)
                regView.errMessage = "很抱歉，信息登记入口已关闭，您将无法登记信息";

            //数据预置
            regView.KidBirth = DateTime.Now;

            return View(regView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(RegSwitch))]
        [ServiceFilter(typeof(reCaptchaValid))]
        public async Task<IActionResult> RegInfo(RegViewModel kidsInfo)
        {
            ViewBag.SystemOptions = _systemOptions;

            if (ModelState.IsValid)
            {
                int isRegistered =  _kidregsContext.KidsInfo.Where(e => e.KidIdCard == kidsInfo.KidIdCard).Count();
                //return Content(isRegistered.ToString());
                if (isRegistered == 0)
                {
                    _kidregsContext.KidsInfo.Add(kidsInfo.To());
                    await _kidregsContext.SaveChangesAsync();
                    return View("Submitted");
                }
            }

            return RedirectToAction(nameof(Reg), new RegViewModel
            {
                errMessage = "您的信息非法或该身份证号已被登记，请您核对后再提交"
            });
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int errorCode)
        {
            ViewBag.SystemOptions = _systemOptions;
            ViewBag.errorCode = errorCode;
            return View();
        }
    }
}
