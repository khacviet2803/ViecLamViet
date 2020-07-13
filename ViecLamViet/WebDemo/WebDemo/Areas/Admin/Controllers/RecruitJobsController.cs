using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using WebDemo.Utils;

namespace WebDemo.Areas.Admin.Controllers
{
    public class RecruitJobsController : Controller
    {
        private MyDbContext db = new MyDbContext();


        // GET: Admin/RecruitJobs/Create
        public ActionResult Create()
        {
            //ViewBag.RecruitInfoId = new SelectList(db.RecruitInfos, "Id", "About");
            return View();
        }

        // POST: Admin/RecruitJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecruitInfoId,RecruitPosition,Amount,Describe,Require,OtherRequire,RayOfPay,ComplateDate")] RecruitJob recruitJob)
        {
            recruitJob.RecruitInfoId = db.RecruitInfos.Where(x=>x.MasterId ==  XSession.Master.Id).FirstOrDefault().Id;
            recruitJob.Describe = recruitJob.Describe.Replace("\r\n", "%3Cbr%20/%3E");
            recruitJob.Require = recruitJob.Require.Replace("\r\n", "%3Cbr%20/%3E");
            recruitJob.OtherRequire = recruitJob.OtherRequire.Replace("\r\n", "%3Cbr%20/%3E");
            recruitJob.PostDate = DateTime.Now;
            recruitJob.endJob = false;
            if (ModelState.IsValid)
            {
                db.RecruitJobs.Add(recruitJob);
                db.SaveChanges();
                var data = db.RecruitJobs.Where(x => x.RecruitInfo.MasterId == XSession.Master.Id).Select(x => x).ToList();
          
                return RedirectToAction("ShowRecruitJob", "Master", data);
            }

         
            return View(recruitJob);
        }

        // GET: Admin/RecruitJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitJob recruitJob = db.RecruitJobs.Find(id);
            if (recruitJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecruitInfoId = new SelectList(db.RecruitInfos, "Id", "About", recruitJob.RecruitInfoId);
            recruitJob.Describe = recruitJob.Describe.Replace( "%3Cbr%20/%3E", "\r\n");
            recruitJob.Require = recruitJob.Require.Replace("%3Cbr%20/%3E", "\r\n");
            recruitJob.OtherRequire = recruitJob.OtherRequire.Replace("%3Cbr%20/%3E", "\r\n");
            return View(recruitJob);
        }

        // POST: Admin/RecruitJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecruitPosition,Amount,Describe,Require,OtherRequire,RayOfPay,PostDate,ComplateDate")] RecruitJob recruitJob)
        {
            if (ModelState.IsValid)
            {
                var info = db.RecruitJobs.Where(x => x.Id == recruitJob.Id).FirstOrDefault();



                info.Describe = recruitJob.Describe.Replace("\r\n", "%3Cbr%20/%3E");
                info.Require = recruitJob.Require.Replace("\r\n", "%3Cbr%20/%3E");
                info.OtherRequire = recruitJob.OtherRequire.Replace("\r\n", "%3Cbr%20/%3E");
                info.RecruitPosition = recruitJob.RecruitPosition;
                info.Amount = recruitJob.Amount;             
                info.ComplateDate = recruitJob.ComplateDate;
                info.endJob = recruitJob.endJob;
                info.PostDate = recruitJob.PostDate;
                info.RayOfPay = recruitJob.RayOfPay;
              
              
                //db.Entry(recruitJob).State = EntityState.Modified;
                db.SaveChanges();
                var data = db.RecruitJobs.Where(x => x.Id == recruitJob.Id).Select(x => x).Single();
                return RedirectToAction("Detail","Master", data);
            }
            ViewBag.RecruitInfoId = new SelectList(db.RecruitInfos, "Id", "About", recruitJob.RecruitInfoId);
            return View(recruitJob);
        }

      
        public ActionResult EndJob(int? id)
        {

            var temp = db.RecruitJobs.Where(x => x.Id == id).FirstOrDefault();
            temp.endJob = true;
            db.SaveChanges();

            var data = db.RecruitJobs.Where(x => x.RecruitInfo.MasterId == XSession.Master.Id).Select(x => x).ToList();

            return RedirectToAction("ShowRecruitJob", "Master", data);
        }

        public ActionResult OpenJob(int? id)
        {

            var temp = db.RecruitJobs.Where(x => x.Id == id).FirstOrDefault();
            temp.endJob = false;
            db.SaveChanges();

            var data = db.RecruitJobs.Where(x => x.RecruitInfo.MasterId == XSession.Master.Id).Select(x => x).ToList();

            return RedirectToAction("ShowRecruitJob", "Master", data);
        }

    }
}
