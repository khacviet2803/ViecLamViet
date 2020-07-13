using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class CandidateInfo
    {
        public CandidateInfo()
        {
            this.CandidatePostResumes = new HashSet<CandidatePostResume>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Giới Tính")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Kĩ Năng")]
        public string Skill { get; set; }
        [Required]
        [Display(Name = "Trình Độ")]
        public string Level { get; set; }
        [Required]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }       
        public virtual ICollection<CandidatePostResume> CandidatePostResumes { get; set; }
    }
}