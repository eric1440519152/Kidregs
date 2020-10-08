using System;
using System.Collections.Generic;

namespace Kidregs.Models
{
    public partial class KidsInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birth { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Others { get; set; }
    }
}
