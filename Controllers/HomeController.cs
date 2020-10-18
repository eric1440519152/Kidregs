using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EasyOffice.Interfaces;
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
        private readonly IWordExportService _wordExportService;

        public HomeController(ILogger<HomeController> logger,KidregsContext kidregsContext,IWordExportService wordExportService)
        {
            _logger = logger;
            _kidregsContext = kidregsContext;
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

        public IActionResult Reg()
        {
            var nationLists = _kidregsContext.NationList.ToList();
            return View(new RegViewModel{NationLists = nationLists});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegInfo(RegViewModel kidsInfo)
        {

            if (ModelState.IsValid)
            {
                int isRegistered =  _kidregsContext.KidsInfo.Where(e => e.KidIdCard == kidsInfo.KidIdCard).Count();
                if (isRegistered != 0)
                {
                    Response.StatusCode = 404;
                    return Content("记录已经存在，请勿重复提交");
                }
                else
                {
                    _kidregsContext.KidsInfo.Add(kidsInfo.To());
                    await _kidregsContext.SaveChangesAsync();
                }
                
            }
            return Content(ModelState.IsValid.ToString());
            //return View();
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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
