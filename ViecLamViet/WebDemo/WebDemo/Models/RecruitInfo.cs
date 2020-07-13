using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class RecruitInfo
    {
        public RecruitInfo()
        {
          
            this.RecruitJobs = new HashSet<RecruitJob>();
            //this.Masters = new HashSet<Master>();
           
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Giới Thiệu")]

        public string About { get; set; }
        [Required]
        [Display(Name = "Giới Thiệu Khác")]
        public string OtherRequire { get; set; }
        [Required]
        [Display(Name = "Logo")]
        public string Logo { get; set; }
        [Required]
        [Display(Name = "Poster")]
        public string poster { get; set; }
        [Required]
        [Display(Name = "Địa Chỉ Google Map")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Thành Phố")]
        public string City { get; set; }

        public int MasterId { get; set; }

        public virtual Master Master { get; set; }

        //public virtual ICollection<Master> Masters { get; set; }

        public virtual ICollection<RecruitJob> RecruitJobs { get; set; }
       

    }
}