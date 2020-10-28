using System;
using System.Collections.Generic;
using EasyOffice.Attributes;
using Kidregs.Models;

namespace Kidregs.ViewModels.Dashboard
{
    public partial class OutputInfo
    {
        [ColName("姓名")]
        public string KidName { get; set; }
        [ColName("身份证号")]
        public string KidIdCard { get; set; }
        [ColName("性别")]
        public string KidGender { get; set; }
        [ColName("民族")]
        public string KidNation { get; set; }
        [ColName("户口类型")]
        public string KidHouseholdType { get; set; }
        [ColName("户口所在地")]
        public string KidRegRes { get; set; }
        [ColName("户籍地")]
        public string KidDomicile { get; set; }
        [ColName("生日")]
        public string KidBirth { get; set; }
        [ColName("父亲姓名")]
        public string DadName { get; set; }
        [ColName("父亲工作单位")]
        public string DadWorkRes { get; set; }
        [ColName("父亲电话")]
        public string DadPhone { get; set; }
        [ColName("父亲身份证号")]
        public string DadIdCard { get; set; }
        [ColName("母亲姓名")]
        public string MunName { get; set; }
        [ColName("母亲工作单位")]
        public string MunWorkRes { get; set; }
        [ColName("母亲电话")]
        public string MunPhone { get; set; }
        [ColName("母亲身份证号")]
        public string MunIdCard { get; set; }
        [ColName("家庭住址")]
        public string HomeAddres { get; set; }
        [ColName("祖辈姓名")]
        public string GrandName { get; set; }
        [ColName("祖辈工作单位")]
        public string GrandWorkRes { get; set; }
        [ColName("祖辈电话")]
        public string GrandPhone { get; set; }
        [ColName("是否爱提问")]
        public string LikeAsk { get; set; }
        [ColName("独立饮食")]
        public string IndieEat { get; set; }
        [ColName("和小朋友玩")]
        public string LikePlay { get; set; }
        [ColName("爱阅读")]
        public string LikeRead { get; set; }
        [ColName("和父母交流")]
        public string LikeComm { get; set; }
        [ColName("午睡")]
        public string Nap { get; set; }
        [ColName("乐于助人")]
        public string Accommodating { get; set; }
        [ColName("勤洗手")]
        public string WashHand { get; set; }
        [ColName("独立穿衣")]
        public string Dress { get; set; }
        [ColName("独立大便")]
        public string Defecate { get; set; }
        [ColName("刷牙")]
        public string BrushTeeth { get; set; }
        [ColName("独立小便")]
        public string Urinate { get; set; }
        [ColName("起床时间")]
        public string GetUpTime { get; set; }
        [ColName("睡觉时间")]
        public string SleepTime { get; set; }
        [ColName("喜爱食物")]
        public string LikeFood { get; set; }
        [ColName("既往病史")]
        public string Case { get; set; }
        [ColName("一餐多长时间")]
        public string MealLength { get; set; }
        [ColName("过敏食物")]
        public string SensibiligenFood { get; set; }
        [ColName("高烧史")]
        public string Fever { get; set; }
        [ColName("过敏药物")]
        public string SensibiligenMedicine { get; set; }
        [ColName("兴趣爱好")]
        public string Hobbies { get; set; }
        [ColName("备注")]
        public string Others { get; set; }

        public void From(KidsInfo kidsInfo)
        {
            KidName = kidsInfo.KidName;
            KidIdCard = kidsInfo.KidIdCard;
            KidGender = kidsInfo.KidGender;
            KidNation = kidsInfo.KidNation;
            KidHouseholdType = kidsInfo.KidHouseholdType;
            KidRegRes = kidsInfo.KidRegRes;
            KidDomicile = kidsInfo.KidDomicile;
            KidBirth = kidsInfo.KidBirth.ToString("yyyy年M月d日");
            DadName = kidsInfo.DadName;
            DadWorkRes = kidsInfo.DadWorkRes;
            DadPhone = kidsInfo.DadPhone;
            DadIdCard = kidsInfo.DadIdCard;
            MunName = kidsInfo.MunName;
            MunWorkRes = kidsInfo.MunWorkRes;
            MunPhone = kidsInfo.MunPhone;
            MunIdCard = kidsInfo.MunIdCard;
            HomeAddres = kidsInfo.HomeAddres;
            GrandName = kidsInfo.GrandName == null ? "" : kidsInfo.GrandName;
            GrandWorkRes = kidsInfo.GrandWorkRes == null ? "" :kidsInfo.GrandWorkRes;
            GrandPhone = kidsInfo.GrandPhone== null ? "" :kidsInfo.GrandPhone;
            LikeAsk = kidsInfo.LikeAsk;
            IndieEat = kidsInfo.IndieEat;
            LikePlay = kidsInfo.LikePlay;
            LikeRead = kidsInfo.LikeRead;
            Nap = kidsInfo.Nap;
            Accommodating = kidsInfo.Accommodating;
            WashHand = kidsInfo.WashHand;
            Dress = kidsInfo.Dress;
            Defecate = kidsInfo.Defecate;
            LikeComm = kidsInfo.LikeComm;
            BrushTeeth = kidsInfo.BrushTeeth;
            Urinate = kidsInfo.Urinate;
            GetUpTime = kidsInfo.GetUpTime.ToString("HH:mm");
            SleepTime = kidsInfo.SleepTime.ToString("HH:mm");
            LikeFood = kidsInfo.LikeFood;
            Case = kidsInfo.Case;
            MealLength = kidsInfo.MealLength;
            SensibiligenFood = kidsInfo.SensibiligenFood;
            Fever = kidsInfo.Fever;
            SensibiligenMedicine = kidsInfo.SensibiligenMedicine;
            Hobbies = kidsInfo.Hobbies;
            Others = kidsInfo.Others== null ? "" :kidsInfo.Others;
        }
    }
}
