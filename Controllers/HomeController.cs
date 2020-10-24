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
using Kidregs.ViewModels.Home;

namespace Kidregs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KidregsContext _kidregsContext;
        private readonly ISystemOptions _systemOptions;
        private readonly IWordExportService _wordExportService;

        public HomeController(ILogger<HomeController> logger,KidregsContext kidregsContext,ISystemOptions systemOptions,IWordExportService wordExportService)
        {
            _logger = logger;
            _kidregsContext = kidregsContext;
            _systemOptions = systemOptions;
            _wordExportService = wordExportService;
        }

        public IActionResult Index()
        {
            var list = _kidregsContext.KidsInfo.Where(s => s.Id == 1);
            var collection = new List<KidsInfoViewModel>();
            foreach (var s in list)
            {
                collection.Add(new KidsInfoViewModel
                {
                    Id = s.Id,
                    Birth = s.KidBirth,
                    FatherName = s.DadName,
                    Gender = s.KidGender,
                    IdCard = s.KidIdCard,
                    MotherName = s.MunName,
                    Name = s.KidName
                });
            }
            return View(collection);
        }

        public IActionResult Reg(RegViewModel regView)
        {
            ViewBag.SystemOptions = _systemOptions;
            var nationLists = _kidregsContext.NationList.ToList();
            ViewBag.nationLists = nationLists;

            return View(regView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(reCaptchaValid))]
        public async Task<IActionResult> RegInfo(RegViewModel kidsInfo)
        {

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
        /*
        public async Task<IActionResult> Output(int id)
        {
            
            var s = _kidregsContext.KidsInfo.First(e => e.Id == id);
            var model = new KidsInfoViewModel
            {
                Id = s.Id,
                Birth = s.Birth,
                FatherName = s.FatherName,
                Gender = (bool) s.Gender ? "男" : "女",
                IdCard = s.IdCard,
                MotherName = s.MotherName,
                Name = s.Name
            };
            string template = @"Template\Output.docx";
            var word = await _wordExportService.CreateFromTemplateAsync(template,model);
            return File(word.WordBytes,"application/vnd.openxmlformats-officedocument.wordprocessingml.document",model.Name+"的档案.docx");
            
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
