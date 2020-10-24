using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Kidregs.Libraries.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kidregs.Libraries.Class
{
    public class reCAPTCHA
    {
        private readonly string _serverUrl;
        private readonly string _serverKey;

        public reCAPTCHA(ISystemOptions systemOptions)
        {
            _serverUrl = systemOptions.reCAPTCHA_ServerUrl;
            _serverKey = systemOptions.reCAPTCHA_Secret;
        }

        public reCaptchaResult Validate(string token,string ip = null)
        {
            return Task.Run(() =>
            {
                var client = new WebClient();
                var values = new NameValueCollection();

                values["secret"] = _serverKey;
                values["response"] = token;
                if (ip != null)
                    values["remoteip"] = ip;

                var response = client.UploadValues("https://" + _serverUrl + "/recaptcha/api/siteverify ", values);
                var res = JsonConvert.DeserializeObject<reCaptchaResult>(Encoding.Default.GetString(response));

                return res;
            }).Result;
        }

        public class reCaptchaResult
        {
            public bool success;
            public string challenge_ts;
        }
    }

    public class reCaptchaValid:IActionFilter 
    {
        private readonly reCAPTCHA _reCaptcha;
        private readonly ISystemOptions _systemOptions;

        public reCaptchaValid(reCAPTCHA reCaptcha,ISystemOptions systemOptions)
        {
            _reCaptcha = reCaptcha;
            _systemOptions = systemOptions;
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {         
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            
            var r = context.HttpContext.Request.Form.TryGetValue("reCAPTCHA_Token", out StringValues reCaptchaToken);
            //两种情况直接跳转
            //关闭验证码 或 验证通过
            if(_systemOptions.reCAPTCHASwitch)
                if (!_reCaptcha.Validate(reCaptchaToken).success)
                {
                    //context.HttpContext.Response.Redirect("/Home/Reg?);
                    context.Result =new RedirectToActionResult("Reg","Home",new
                    {
                        errMessage = "这位同学，你的想法很危险！绕过验证码不可取"
                    });
                }

        }
    }
    
}
