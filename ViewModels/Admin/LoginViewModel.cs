using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidregs.ViewModels.Admin
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password{ get; set; }
        public bool Remember{ get; set; }
        public string reCAPTCHA_Token { get; set; }
    }
}
