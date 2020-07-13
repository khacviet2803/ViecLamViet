using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class RecruitJob
    {
        public RecruitJob()
        {
            this.CandidatePostResumes = new HashSet<CandidatePostResume>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int RecruitInfoId { get; set; }
        [Required]
        [Display(Name = "Tiêu Đề Tuyển Dụng")]
        public string RecruitPosition { get; set; }
        [Required]
        [Display(Name = "Số Lượng")]
        public int Amount { get; set; }
        [Required]
        [Display(Name = "Mô Tả Công Việc")]
        public string Describe { get; set; }
        [Required]
        [Display(Name = "Yêu Cầu")]
        public string Require { get; set; }
        [Required]
        [Display(Name = "Yêu Cầu Khác")]
        public string OtherRequire { get; set; }
        [Required]
        [Display(Name = "Lương")]
        public string RayOfPay { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Đăng")]
        public DateTime PostDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Hết Hạn")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ComplateDate { get; set; }

        public bool endJob { get; set; }
        public virtual RecruitInfo RecruitInfo { get; set; }

        public virtual ICollection<CandidatePostResume> CandidatePostResumes { get; set; }
    }
}