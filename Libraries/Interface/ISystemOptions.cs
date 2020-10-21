using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidregs.Libraries.Interface
{
    public interface ISystemOptions
    {
        //站点名称
        public string SiteName { get; set; }
        //注册界面提示
        public string WelcomeMessage { get;set; }
        //版权信息文本
        public string CopyrightMessage { get; set; }
        //域名
        public string Domain { get;set; }
        //reCAPTCHA ID
        public string reCAPTCHA_AppId { get; set; }
        //reCAPTCHA
        public string reCAPTCHA_Secret { get; set; }
        public bool RegSwitch { get; set; }
        public void UpdateOptions();
        public void GetOptions();
    }
}
