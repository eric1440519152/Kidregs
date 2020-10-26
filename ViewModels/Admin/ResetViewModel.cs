using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidregs.ViewModels.Admin
{
    public class ResetViewModel
    {
        public string ResetCode { get; set; }
        public string NewPassword { get; set; }
        public string reCAPTCHA_Token { get; set; }
    }
}
