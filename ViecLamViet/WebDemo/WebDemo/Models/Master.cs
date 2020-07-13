using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class Master
    {
        public Master()
        {
            this.MasterRoles = new HashSet<MasterRole>();
           
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Mobile { get; set; }

        //public int RecruitInfoId { get; set; }

        //public virtual RecruitInfo RecruitInfo { get; set; }


        public virtual ICollection<RecruitInfo> RecruitInfos { get; set; }
        public virtual ICollection<MasterRole> MasterRoles { get; set; }
    }
}