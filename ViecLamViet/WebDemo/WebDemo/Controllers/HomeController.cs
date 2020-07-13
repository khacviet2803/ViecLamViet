using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using WebDemo.ModelsView;
using WebDemo.Utils;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            var job = db.RecruitJobs.Where(x => x.endJob == false);
            foreach (var item in job.ToList())
            {
                if(item.ComplateDate < DateTime.Now)
                {
                    item.endJob = true;
                }
            }

            

            var city = db.RecruitInfos.Select(x => x.City).Distinct();
            ViewBag.city = city as SelectList;
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search(string keyword)       
        {
             var data = db.RecruitJobs.Where(x => x.RecruitPosition.Contains(keyword) && x.endJob == false).Select(x => x).ToList();
            return View(data);
        }
        public ActionResult SearchCity(string cars)
        {
            
            return View();
        }
        public ActionResult Detail(int Id)
        {
            var data = db.RecruitJobs.Where(x => x.Id == Id).Select(x => x).Single();
            return View(data);
        }


       

        public ActionResult Apply(int id)
        {
            var data = db.RecruitJobs.Where(x => x.Id == id).Select(x => x).Single();
            ViewBag.temp = data.Amount +" "+ data.RecruitPosition;
            CV cv = new CV();
            cv.id = id;
            if (XSession.User == null)
            {                              
                cv.email = "a@gmail.com";
                cv.name = "Nguyễn Văn A";
            }
            else
            {
                              
                cv.email = XSession.User.Email;
                cv.name = XSession.User.Name;
            }
          
            return View(cv);
        }
       
        public ActionResult Send(CV model)
        {
            
            if(ModelState.IsValid)
            {
                var file = Request.Files["UpCV"];
                if (file == null)
                {
                    return View("Apply");
                }
                if (file.ContentLength > 0)
                {
                    model.cv = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    file.SaveAs(Server.MapPath("~/UploadedFiles/" + model.cv));
                }

                var data = db.RecruitJobs.Where(x => x.Id == model.id).Select(x => x).Single();
                string body = "Xin Chào "+data.RecruitInfo.Master.CompanyName + "\nXin gửi đế công ty thông tin ứng viên:\n"+"Tên Ứng viên: "+model.name+"\nEmail: "+model.email;

                XMailer.Send(data.RecruitInfo.Master.Email, "Ứng Viên " + data.RecruitPosition, body, file);

                if(XSession.User!=null)
                {
                    CandidatePostResume candidatePostResume = new CandidatePostResume();
                    candidatePostResume.CandidateInfoId = XSession.User.Id;
                    candidatePostResume.RecruitJobId = data.Id;
                    candidatePostResume.Date = DateTime.Now;

                    db.CandidatePostResumess.Add(candidatePostResume);
                    db.SaveChanges();
                }
               

                return View();
            }
          
            return View("Apply");
        }

        public ActionResult ShowRecruitInfo(int Id)
        {
           ViewBag.Data = db.RecruitJobs.Where(x => x.RecruitInfo.MasterId == Id && x.endJob == false).Select(x => x).ToList();
            var data = db.RecruitInfos.Where(x => x.MasterId == Id).Select(x => x).Single();
            return View(data);

        }
        public ActionResult EditCandidateInfoes()
        {

            var data = db.CandidateInfos.Where(x => x.Id == XSession.User.Id).Select(x => x).Single();
            return View(data);

        }
        [HttpPost]
        public ActionResult EditCandidateInfoes(CandidateInfo model)
        {
            if (ModelState.IsValid)
            {
                var data = db.CandidateInfos.Where(x => x.Id == XSession.User.Id).Select(x => x).Single();
                data.Name = model.Name;
                data.Gender = model.Gender;
                data.Skill = model.Skill    ;
                data.Level = model.Level;
                data.Address = model.Address;
                data.Phone = model.Phone;

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}