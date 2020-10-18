using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kidregs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kidregs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidController : ControllerBase
    {
        private readonly KidregsContext _kidregsContext;

        public ValidController(KidregsContext kidregsContext)
        {
            _kidregsContext = kidregsContext;
        }
        [HttpGet("IdCard")]
        public string ValidIdCard(string KidIdCard)
        {
            int isRegistered =  _kidregsContext.KidsInfo.Where(e => e.KidIdCard == KidIdCard).Count();
            if (isRegistered != 0)
            {
                Response.StatusCode = 404;
                return "该身份证号的记录已经存在";
            }
            else
            {
                Response.StatusCode = 200;
                return "True";
            }
        }
    }
}
