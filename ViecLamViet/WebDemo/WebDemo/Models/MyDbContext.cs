using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebDemo.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("Demo")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<CandidateInfo> CandidateInfos { get; set; }
        public DbSet<CandidatePostResume> CandidatePostResumess { get; set; }
        public DbSet<RecruitInfo> RecruitInfos { get; set; }
        public DbSet<RecruitJob> RecruitJobs { get; set; }
        public DbSet<ActionRole> ActionRoles { get; set; }
        public DbSet<MasterRole> MasterRoles { get; set; }
        public DbSet<Rolie> Rolies { get; set; }
        public DbSet<WebAction> WebActions { get; set; }
        public DbSet<Master> Masters { get; set; }


    }
}