using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kidregs.Libraries.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Kidregs.Libraries.Class
{
    public class RegSwitch:IActionFilter 
    {
        private readonly ISystemOptions _systemOptions;

        public RegSwitch(ISystemOptions systemOptions)
        {
            _systemOptions = systemOptions;
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {         
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            if(!_systemOptions.RegSwitch)
                context.Result =new RedirectToActionResult("Reg","Home",new
                {
                    errMessage = "很抱歉，信息登记入口已关闭，您无法登记信息"
                });
        }
    }
}
