using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using WebDemo.Utils;

namespace WebDemo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();


        // GET: Admin/Home
        public ActionResult Index()
        {
           
            if (XSession.Master == null)
            {
                return View("Login");
            }
            else
            {
                var RecruitInfo = db.RecruitInfos.SingleOrDefault(x => x.MasterId == XSession.Master.Id);
                if(RecruitInfo ==null)
                {
                    RecruitInfo = new RecruitInfo();
                    RecruitInfo.About = "Vui  lòng nhập thông tin ";
                    RecruitInfo.Address = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.58882286079!2d106.76589431428756!3d10.842745160932221!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317527a7072a3fdd%3A0x11611abae858bcac!2zMjMgVGjhu5FuZyBOaOG6pXQsIELDrG5oIFRo4buNLCBUaOG7pyDEkOG7qWMsIEjhu5MgQ2jDrSBNaW5oLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1592489540528!5m2!1svi!2s";
                    RecruitInfo.City = "Ho Chi Minh";
                    RecruitInfo.Logo = "https://alumni.crg.eu/sites/default/files/default_images/default-picture_0_0.png";
                    RecruitInfo.poster = "https://thegioidohoa.com/wp-content/gallery/thiet-ke-banner-001/Thiet-ke-banner_047.png?fbclid=IwAR3a1WNXqVJ8ua2Hs9t1b0jQ9p_HWZKtLiMloH1Odv2Jst3KhcKT4_OS6eM";
                    RecruitInfo.OtherRequire = "Vui  lòng nhập thông tin";
                    RecruitInfo.MasterId = XSession.Master.Id;
                    RecruitInfo.Master = db.Masters.SingleOrDefault(x => x.Id == XSession.Master.Id);
                    db.RecruitInfos.Add(RecruitInfo);
                    db.SaveChanges();
                }
                return View(RecruitInfo);
            }
        }

        public ActionResult Login(String Reason = "")
        {
            if (Reason.Length > 0)
            {
                ModelState.AddModelError("", Reason);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Id, String Password)
        {
            var Master = db.Masters.SingleOrDefault(x => x.Email == Id && x.Password == Password);
            if (Master == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
                return View();
            }
            else if (Master.Password != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
                return View();
            }
            else
            {
                XSession.Master = Master;
            
                ModelState.AddModelError("", "Đăng nhập thành công");
            }
            return RedirectToAction("Index");
        }

      
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Master user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Vui lòng sửa các lỗi sau đây");
                return View();
            }
          
            // Insert
            try
            {
                db.Masters.Add(user);
               
                db.SaveChanges();

                // Gửi mail
              
                ModelState.AddModelError("", "Đăng ký thành công!");
            }
            catch
            {
                ModelState.AddModelError("", "Đăng ký thất bại!");
            }
            return View();
        }

        public ActionResult Logoff()
        {
            XSession.RemoveMaster();
            return RedirectToAction("Index");
        }
        public ActionResult Change()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Change(String Id, String Password, String Password1, String Password2)
        {
            if (Password1 != Password2)
            {
                ModelState.AddModelError("", "Xác nhận mật khẩu mới không đúng!");
            }
            else
            {
                var user = db.Masters.Where(x => x.Email == Id).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("", "Sai tên đăng nhâp!");
                }
                else if (user.Password != Password)
                {
                    ModelState.AddModelError("", "Sai mật khẩu!");
                }
                else
                {
                    user.Password = Password1;
                    db.SaveChanges();

                    ModelState.AddModelError("", "Đổi mật khẩu thành công!");
                }
            }
            return View();
        }
    }
}