
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using WebDemo.Utils;

namespace WebDemo.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        MyDbContext db = new MyDbContext();

     

        public ActionResult Edit()
        {
            Master master = XSession.Master;
            RecruitInfo recruitInfo =  db.RecruitInfos.Where(x => x.MasterId == master.Id).SingleOrDefault();
            recruitInfo.About =  recruitInfo.About.Replace( "%3Cbr%20/%3E", "\r\n");
            recruitInfo.OtherRequire =  recruitInfo.OtherRequire.Replace( "%3Cbr%20/%3E", "\r\n");
         
            return View(recruitInfo);
        }
        [HttpPost]
        public ActionResult Edit(RecruitInfo model)
        {
            RecruitInfo recruitInfo = db.RecruitInfos.Where(x => x.Id == model.Id).SingleOrDefault();

            recruitInfo.About = model.About.Replace("\r\n", "%3Cbr%20/%3E");
            recruitInfo.Address = model.Address;
            recruitInfo.City = model.City;
            recruitInfo.Logo = model.Logo;
            recruitInfo.poster = model.poster;
            recruitInfo.OtherRequire = model.OtherRequire.Replace("\r\n", "%3Cbr%20/%3E");
            
          
            db.SaveChanges();
            return RedirectToAction("Index","Home",model);
        }
        public ActionResult ShowRecruitJob()
        {
           
            var data = db.RecruitJobs.Where(x => x.RecruitInfo.MasterId == XSession.Master.Id).Select(x => x).ToList();
            return View(data);
      
        }
        public ActionResult Detail(int Id)
        {
            var data = db.RecruitJobs.Where(x => x.Id == Id).Select(x => x).Single();
            return View(data);

        }
        public ActionResult ShowCandidate()
        {
            var data = db.CandidateInfos.Select(x => x).ToList();
            return View(data);

        }

    }
}