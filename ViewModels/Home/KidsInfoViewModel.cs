using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidregs.ViewModels.Home
{
    public class KidsInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public string Gender { get; set; }
        public DateTime? Birth { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}
