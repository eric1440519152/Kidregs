using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Kidregs.Models;
using NPOI.Util;

namespace Kidregs.ViewModels.Home
{
    public class RegViewModel
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        [Required]
        public string KidName { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$",ErrorMessage = "请输入正确的身份证号")]
        public string KidIdCard { get; set; }
        [Required]
        public string KidGender { get; set; }
        [Required]
        public string KidNation { get; set; }
        [Required]
        public string KidHouseholdType { get; set; }
        [Required]
        public string KidRegRes { get; set; }
        [Required]
        public string KidDomicile { get; set; }
        [Required]
        public DateTime KidBirth { get; set; }
        [Required]
        public string DadName { get; set; }
        [Required]
        public string DadWorkRes { get; set; }
        [Required]
        [RegularExpression(@"^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$",ErrorMessage = "请输入正确的手机号码")]
        public string DadPhone { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$",ErrorMessage = "请输入正确的身份证号")]
        public string DadIdCard { get; set; }
        [Required]
        public string MunName { get; set; }
        [Required]
        public string MunWorkRes { get; set; }
        [Required]
        [RegularExpression(@"^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$",ErrorMessage = "请输入正确的手机号码")]
        public string MunPhone { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$",ErrorMessage = "请输入正确的身份证号")]
        public string MunIdCard { get; set; }
        [Required]
        public string HomeAddres { get; set; }
        public string GrandName { get; set; }
        public string GrandWorkRes { get; set; }
        [RegularExpression(@"^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$",ErrorMessage = "请输入正确的手机号码")]
        public string GrandPhone { get; set; }
        [Required]
        public string LikeAsk { get; set; }
        [Required]
        public string IndieEat { get; set; }
        [Required]
        public string LikePlay { get; set; }
        [Required]
        public string LikeRead { get; set; }
        [Required]
        public string LikeComm { get; set; }
        [Required]
        public string Nap { get; set; }
        [Required]
        public string Accommodating { get; set; }
        [Required]
        public string WashHand { get; set; }
        [Required]
        public string Dress { get; set; }
        [Required]
        public string Defecate { get; set; }
        [Required]
        public string BrushTeeth { get; set; }
        [Required]
        public string Urinate { get; set; }
        [Required]
        public DateTime GetUpTime { get; set; }
        [Required]
        public DateTime SleepTime { get; set; }
        [Required]
        public string LikeFood { get; set; }
        [Required]
        public string Case { get; set; }
        [Required]
        public string MealLength { get; set; }
        [Required]
        public string SensibiligenFood { get; set; }
        [Required]
        public string Fever { get; set; }
        [Required]
        public string SensibiligenMedicine { get; set; }
        [Required]
        public string Hobbies { get; set; }
        public string Others { get; set; }

        public string reCAPTCHA_Token { get; set; }
        public string errMessage { get; set; }
        public void From(KidsInfo kids)
        {
            Id = kids.Id;
            KidName = kids.KidName;
            KidIdCard = kids.KidIdCard;
            KidGender = kids.KidGender;
            KidNation = kids.KidNation;
            KidHouseholdType = kids.KidHouseholdType;
            KidRegRes = kids.KidRegRes;
            KidDomicile = kids.KidDomicile;
            KidBirth = kids.KidBirth;
            DadName = kids.DadName;
            DadWorkRes = kids.DadWorkRes;
            DadPhone = kids.DadPhone;
            DadIdCard = kids.DadIdCard;
            MunName = kids.MunName;
            MunWorkRes = kids.MunWorkRes;
            MunPhone = kids.MunPhone;
            MunIdCard = kids.MunIdCard;
            HomeAddres = kids.HomeAddres;
            GrandName = kids.GrandName;
            GrandWorkRes = kids.GrandWorkRes;
            GrandPhone = kids.GrandPhone;
            LikeAsk = kids.LikeAsk;
            IndieEat = kids.IndieEat;
            LikePlay = kids.LikePlay;
            LikeRead = kids.LikeRead;
            Nap = kids.Nap;
            Accommodating = kids.Accommodating;
            WashHand = kids.WashHand;
            Dress = kids.Dress;
            Defecate = kids.Defecate;
            BrushTeeth = kids.BrushTeeth;
            Urinate = kids.Urinate;
            GetUpTime = kids.GetUpTime;
            SleepTime = kids.SleepTime;
            LikeFood = kids.LikeFood;
            Case = kids.Case;
            LikeComm = kids.LikeComm;
            MealLength = kids.MealLength;
            SensibiligenFood = kids.SensibiligenFood;
            Fever = kids.Fever;
            SensibiligenMedicine = kids.SensibiligenMedicine;
            Hobbies = kids.Hobbies;
            Others = kids.Others;
        }

        public KidsInfo To()
        {
            return new KidsInfo
            {
                Id = this.Id,
                KidName = this.KidName,
                KidIdCard = this.KidIdCard,
                KidGender = this.KidGender,
                KidNation = this.KidNation,
                KidHouseholdType = this.KidHouseholdType,
                KidRegRes = this.KidRegRes,
                KidDomicile = this.KidDomicile,
                KidBirth = this.KidBirth,
                DadName = this.DadName,
                DadWorkRes = this.DadWorkRes,
                DadPhone = this.DadPhone,
                DadIdCard = this.DadIdCard,
                MunName = this.MunName,
                MunWorkRes = this.MunWorkRes,
                MunPhone = this.MunPhone,
                MunIdCard = this.MunIdCard,
                HomeAddres = this.HomeAddres,
                GrandName = this.GrandName,
                GrandWorkRes = this.GrandWorkRes,
                GrandPhone = this.GrandPhone,
                LikeAsk = this.LikeAsk,
                IndieEat = this.IndieEat,
                LikePlay = this.LikePlay,
                LikeRead = this.LikeRead,
                Nap = this.Nap,
                LikeComm = LikeComm,
                Accommodating = this.Accommodating,
                WashHand = this.WashHand,
                Dress = this.Dress,
                Defecate = this.Defecate,
                BrushTeeth = this.BrushTeeth,
                Urinate = this.Urinate,
                GetUpTime = this.GetUpTime,
                SleepTime = this.SleepTime,
                LikeFood = this.LikeFood,
                Case = this.Case,
                MealLength = this.MealLength,
                SensibiligenFood = this.SensibiligenFood,
                Fever = this.Fever,
                SensibiligenMedicine = this.SensibiligenMedicine,
                Hobbies = this.Hobbies,
                Others = this.Others
            };
        }
    }
}
