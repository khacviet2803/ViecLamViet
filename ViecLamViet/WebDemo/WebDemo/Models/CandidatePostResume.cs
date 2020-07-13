using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class CandidatePostResume
    {
        [Key]
        public int Id { get; set; }
        public string CandidateInfoId { get; set; }
        public int RecruitJobId { get; set; }
        public DateTime Date { get; set; }

        public virtual CandidateInfo CandidateInfo { get; set; }
        public virtual RecruitJob RecruitJob { get; set; }
    }
}