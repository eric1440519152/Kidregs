using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidregs.ViewModels.Dashboard
{
    public class KidsInfoViewModel
    {
        public int Id { get; set; }
        public string KidName { get; set; }
        public string KidIdCard { get; set; }
        public string DadName { get; set; }
        public string DadPhone { get; set; }
        public string MunName { get; set; }
        public string MunPhone { get; set; }
    }
}
