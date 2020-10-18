using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kidregs.Libraries.Class
{
    public class reCAPTCHA
    {
        private readonly string _serverUrl;
        private readonly string _serverKey;

        public reCAPTCHA(string serverUrl, string serverKey)
        {
            _serverUrl = serverUrl;
            _serverKey = serverKey;
        }

        public reCaptchaResult validate(string token,string ip = null)
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
    
}
