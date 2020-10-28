﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyOffice.Enums;
using EasyOffice.Interfaces;
using EasyOffice.Models.Excel;
using Kidregs.Libraries.Interface;
using Kidregs.Models;
using Kidregs.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Kidregs.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IOptions<KidregsOptions> _options;
        private readonly KidregsContext _kidregsContext;
        private readonly ISystemOptions _systemOptions;
        private readonly IWordExportService _wordExportService;
        private readonly IExcelExportService _excelExportService;

        public DashboardController(IOptions<KidregsOptions> options,KidregsContext kidregsContext,ISystemOptions systemOptions,IWordExportService wordExportService,IExcelExportService excelExportService)
        {
            _options = options;
            _kidregsContext = kidregsContext;
            _systemOptions = systemOptions;
            _wordExportService = wordExportService;
            _excelExportService = excelExportService;
        }

        public IActionResult Index(string errMessage)
        {
            ViewBag.SystemOptions = _systemOptions;
            ViewBag.errMessage = errMessage;

            var list = _kidregsContext.KidsInfo.ToList();
            var collection = new List<KidsInfoViewModel>();

            foreach (var unit in list)
            {
                collection.Add(new KidsInfoViewModel
                {
                    Id = unit.Id,
                    DadName = unit.DadName,
                    DadPhone = unit.DadPhone,
                    KidName = unit.KidName,
                    KidIdCard = unit.KidIdCard,
                    MunName = unit.MunName,
                    MunPhone = unit.MunPhone
                });
            }

            return View(collection);
        }

        public async Task<IActionResult> AllToExcel()
        {
            var list = _kidregsContext.KidsInfo.ToList();
            var outputlist = ConvertToOutputInfo(list);

            var bytes = await _excelExportService.ExportAsync<OutputInfo>(outputlist,new ExportOption<OutputInfo>()
            {
                DataRowStartIndex = 1, //数据行起始索引，默认1
                ExportType = ExportType.XLSX,//导出Excel类型，默认xls
                HeaderRowIndex = 0, //表头行索引，默认0
                SheetName = "sheet1" //页签名称，默认sheet1
                
            });
            return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Output.xlsx");
        }

        private List<OutputInfo> ConvertToOutputInfo(List<KidsInfo> list)
        {
            var outputlist = new List<OutputInfo>();

            foreach (var unitInfo in list)
            {
                var temp = new OutputInfo();
                temp.From(unitInfo);
                outputlist.Add(temp);
            }

            return outputlist;
        }

        public IActionResult SingleDownload(int id)
        {
            var s = _kidregsContext.KidsInfo.First(e => e.Id == id);
            var output = new OutputInfo();
            output.From(s);

            string template = @"Template\Output.docx";
            var word =  _wordExportService.CreateFromTemplateAsync(template,output).Result;
            return File(word.WordBytes,"application/vnd.openxmlformats-officedocument.wordprocessingml.document",s.KidName+"的档案.docx");
        }

        public IActionResult AllToDocx()
        {
            var list = _kidregsContext.KidsInfo.ToList();
            var outputlist = ConvertToOutputInfo(list);

            foreach (var unit in outputlist)
            {
                SingleOutputFile(unit);
            }

            return Content("导出完成");

        }

        private void SingleOutputFile(OutputInfo info)
        {
            string template = @"Template\Output.docx";
            var word =  _wordExportService.CreateFromTemplateAsync(template,info).Result;
            System.IO.File.WriteAllBytes(@"wwwroot\temp\"+info.KidName+info.KidIdCard.ToString()+"的档案.docx", word.WordBytes);
        }

        [HttpPost]
        public IActionResult DelSingle(int id)
        {
            var user = _kidregsContext.KidsInfo.Where(e => e.Id == id).FirstOrDefault();
            if (user == null)
            {
                Response.StatusCode = 404;
                return Content("无此ID记录");
            }
            else
            {
                _kidregsContext.KidsInfo.Remove(user);
                _kidregsContext.SaveChanges();
            }

            return Content("已删除");
        }

        [HttpPost]
        public IActionResult DelAll(string superPassword)
        {
            if (superPassword == _options.Value.SuperPassword)
            {
                ClearKidregs();
                return Content("成功删除");
            }
            else
            {
                Response.StatusCode = 401;
                return Content("超级密码校验失败");
            }
        }

        private void ClearKidregs()
        {
            var delete = _kidregsContext.KidsInfo.Where(e => true);
            foreach (var item in delete)
            {
                _kidregsContext.KidsInfo.Remove(item);
            }
            _kidregsContext.SaveChanges();
        }
    }
}
