namespace WebDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolieId = c.String(maxLength: 128),
                        WebActionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rolies", t => t.RolieId)
                .ForeignKey("dbo.WebActions", t => t.WebActionId, cascadeDelete: true)
                .Index(t => t.RolieId)
                .Index(t => t.WebActionId);
            
            CreateTable(
                "dbo.Rolies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasterRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(nullable: false),
                        RolieId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Masters", t => t.MasterId, cascadeDelete: true)
                .ForeignKey("dbo.Rolies", t => t.RolieId)
                .Index(t => t.MasterId)
                .Index(t => t.RolieId);
            
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecruitInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        About = c.String(nullable: false),
                        OtherRequire = c.String(nullable: false),
                        Logo = c.String(nullable: false),
                        poster = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        MasterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Masters", t => t.MasterId, cascadeDelete: true)
                .Index(t => t.MasterId);
            
            CreateTable(
                "dbo.RecruitJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecruitInfoId = c.Int(nullable: false),
                        RecruitPosition = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        Describe = c.String(nullable: false),
                        Require = c.String(nullable: false),
                        OtherRequire = c.String(nullable: false),
                        RayOfPay = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        ComplateDate = c.DateTime(nullable: false),
                        endJob = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecruitInfoes", t => t.RecruitInfoId, cascadeDelete: true)
                .Index(t => t.RecruitInfoId);
            
            CreateTable(
                "dbo.CandidatePostResumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateInfoId = c.String(maxLength: 128),
                        RecruitJobId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CandidateInfoes", t => t.CandidateInfoId)
                .ForeignKey("dbo.RecruitJobs", t => t.RecruitJobId, cascadeDelete: true)
                .Index(t => t.CandidateInfoId)
                .Index(t => t.RecruitJobId);
            
            CreateTable(
                "dbo.CandidateInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Skill = c.String(nullable: false),
                        Level = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActionRoles", "WebActionId", "dbo.WebActions");
            DropForeignKey("dbo.MasterRoles", "RolieId", "dbo.Rolies");
            DropForeignKey("dbo.RecruitJobs", "RecruitInfoId", "dbo.RecruitInfoes");
            DropForeignKey("dbo.CandidatePostResumes", "RecruitJobId", "dbo.RecruitJobs");
            DropForeignKey("dbo.CandidatePostResumes", "CandidateInfoId", "dbo.CandidateInfoes");
            DropForeignKey("dbo.RecruitInfoes", "MasterId", "dbo.Masters");
            DropForeignKey("dbo.MasterRoles", "MasterId", "dbo.Masters");
            DropForeignKey("dbo.ActionRoles", "RolieId", "dbo.Rolies");
            DropIndex("dbo.CandidatePostResumes", new[] { "RecruitJobId" });
            DropIndex("dbo.CandidatePostResumes", new[] { "CandidateInfoId" });
            DropIndex("dbo.RecruitJobs", new[] { "RecruitInfoId" });
            DropIndex("dbo.RecruitInfoes", new[] { "MasterId" });
            DropIndex("dbo.MasterRoles", new[] { "RolieId" });
            DropIndex("dbo.MasterRoles", new[] { "MasterId" });
            DropIndex("dbo.ActionRoles", new[] { "WebActionId" });
            DropIndex("dbo.ActionRoles", new[] { "RolieId" });
            DropTable("dbo.WebActions");
            DropTable("dbo.CandidateInfoes");
            DropTable("dbo.CandidatePostResumes");
            DropTable("dbo.RecruitJobs");
            DropTable("dbo.RecruitInfoes");
            DropTable("dbo.Masters");
            DropTable("dbo.MasterRoles");
            DropTable("dbo.Rolies");
            DropTable("dbo.ActionRoles");
        }
    }
}
