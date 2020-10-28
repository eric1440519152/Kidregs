using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using Kidregs.Libraries.Interface;
using Kidregs.Models;
using Microsoft.EntityFrameworkCore;
using System = Kidregs.Models.System;

namespace Kidregs.Libraries.Class
{
    public class SystemOptions:ISystemOptions
    {
        private readonly KidregsContext _kidregsContext;
        private Models.System System { get; set; }

        public SystemOptions(KidregsContext kidregsContext)
        {
            _kidregsContext = kidregsContext;
            System = _kidregsContext.System
                .AsNoTracking()
                .First();
            SiteName = System.SiteName;
            WelcomeMessage = System.WelcomeMessage;
            CopyrightMessage = System.CopyrightMessage;
            Domain = System.Domain;
            reCAPTCHA_ServerUrl = System.reCAPTCHA_ServerUrl;
            reCAPTCHA_AppId = System.reCAPTCHA_AppId;
            reCAPTCHA_Secret = System.reCAPTCHA_Secret;
            reCAPTCHASwitch = System.reCAPTCHASwitch;
            RegSwitch = System.RegSwitch;
        }
        //站点名称
        public string SiteName { get; set; }
        //注册界面提示
        public string WelcomeMessage { get;set; }
        //版权信息文本
        public string CopyrightMessage { get; set; }
        //域名
        public string Domain { get;set; }
        public string reCAPTCHA_ServerUrl { get; set; }
        //reCAPTCHA ID
        public string reCAPTCHA_AppId { get; set; }
        //reCAPTCHA
        public string reCAPTCHA_Secret { get; set; }
        public bool reCAPTCHASwitch { get; set; }
        public bool RegSwitch { get; set; }

        public void UpdateOptions()
        {
            System.SiteName = SiteName;
            System.WelcomeMessage = WelcomeMessage;
            System.CopyrightMessage = CopyrightMessage;
            System.Domain = Domain;
            System.RegSwitch = RegSwitch;
            System.reCAPTCHA_ServerUrl = reCAPTCHA_ServerUrl;
            System.reCAPTCHA_AppId = reCAPTCHA_AppId;
            System.reCAPTCHA_Secret = reCAPTCHA_Secret;
            System.reCAPTCHASwitch = reCAPTCHASwitch;
            _kidregsContext.SaveChanges();
        }
        public void GetOptions()
        {
            System = _kidregsContext.System.First();
            SiteName = System.SiteName;
            WelcomeMessage = System.WelcomeMessage;
            CopyrightMessage = System.CopyrightMessage;
            Domain = System.Domain;
            reCAPTCHA_ServerUrl = System.reCAPTCHA_ServerUrl;
            reCAPTCHA_AppId = System.reCAPTCHA_AppId;
            reCAPTCHA_Secret = System.reCAPTCHA_Secret;
            reCAPTCHASwitch = System.reCAPTCHASwitch;
            RegSwitch = System.RegSwitch;
        }
    }
}
