using System;
using System.Collections.Generic;

namespace Kidregs.Models
{
    public partial class KidsInfo
    {
        public int Id { get; set; }
        public string KidName { get; set; }
        public string KidIdCard { get; set; }
        public string KidGender { get; set; }
        public string KidNation { get; set; }
        public string KidHouseholdType { get; set; }
        public string KidRegRes { get; set; }
        public string KidDomicile { get; set; }
        public DateTime KidBirth { get; set; }
        public string DadName { get; set; }
        public string DadWorkRes { get; set; }
        public string DadPhone { get; set; }
        public string DadIdCard { get; set; }
        public string MunName { get; set; }
        public string MunWorkRes { get; set; }
        public string MunPhone { get; set; }
        public string MunIdCard { get; set; }
        public string HomeAddres { get; set; }
        public string GrandName { get; set; }
        public string GrandWorkRes { get; set; }
        public string GrandPhone { get; set; }
        public string LikeAsk { get; set; }
        public string IndieEat { get; set; }
        public string LikePlay { get; set; }
        public string LikeRead { get; set; }
        public string LikeComm { get; set; }
        public string Nap { get; set; }
        public string Accommodating { get; set; }
        public string WashHand { get; set; }
        public string Dress { get; set; }
        public string Defecate { get; set; }
        public string BrushTeeth { get; set; }
        public string Urinate { get; set; }
        public DateTime GetUpTime { get; set; }
        public DateTime SleepTime { get; set; }
        public string LikeFood { get; set; }
        public string Case { get; set; }
        public string MealLength { get; set; }
        public string SensibiligenFood { get; set; }
        public string Fever { get; set; }
        public string SensibiligenMedicine { get; set; }
        public string Hobbies { get; set; }
        public string Others { get; set; }
    }
}
