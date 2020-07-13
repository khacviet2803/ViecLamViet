
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Areas.Admin.Controllers
{
    public class WebActionController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            var model = new WebAction();
            ViewBag.Items = db.WebActions.ToList();
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = db.WebActions.Single(x => x.Id == Id);
            ViewBag.Items = db.WebActions.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(WebAction entity)
        {
            try
            {
                db.WebActions.Add(entity);
                db.SaveChanges();
              
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(WebAction entity)
        {
            try
            {
                var temp =db.WebActions.Single(x=>x.Id ==entity.Id);
                temp.Name = entity.Name;
                temp.ActionRoles = entity.ActionRoles;
                temp.Description = entity.Description;
            
                db.SaveChanges();
                   TempData["Message"] = "Cập nhật thành công!";
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại!";
            }
            return RedirectToAction("Edit", new { entity.Id });
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                var entity = db.WebActions.Single(x => x.Id == Id);
                db.WebActions.Remove(entity);
                db.SaveChanges();
                 TempData["Message"] = "Xóa thành công!";
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}