
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Areas.Admin.Controllers
{
    public class RolieController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            var model = new Rolie();
            ViewBag.Items = db.Rolies.ToList();
            return View(model);
        }

        public ActionResult Edit(string Id)
        {
            var model = db.Rolies.Single(x => x.Id == Id);
            ViewBag.Items = db.Rolies.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(Rolie entity)
        {
            try
            {
                db.Rolies.Add(entity);
                db.SaveChanges();
                 TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(Rolie entity)
        {
            try
            {
                var temp = db.Rolies.Single(x => x.Id == entity.Id);
                temp.Id = entity.Id;
                temp.MasterRoles = entity.MasterRoles;
                temp.Name = entity.Name;
                temp.ActionRoles = entity.ActionRoles;
                db.SaveChanges();
                db.SaveChanges();

                TempData["Message"] = "Cập nhật thành công!";
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại!";
            }
            return RedirectToAction("Edit", new { entity.Id });
        }

        public ActionResult Delete(string Id)
        {
            try
            {
                var entity = db.Rolies.Single(x => x.Id == Id);
                db.Rolies.Remove(entity);
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