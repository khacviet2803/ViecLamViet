
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;

namespace WebDemo.Areas.Admin.Controllers
{
    public class MasterRoleController : Controller
    {
        MyDbContext db = new MyDbContext();

        // GET: Admin/MasterRole
        public ActionResult Index()
        {
           
            ViewBag.MasterId = new SelectList(db.MasterRoles.ToList(), "Id", "MasterId");
            ViewBag.Roles = db.Rolies.ToList();

            return View();
        }

        public ActionResult GetRoleIds(int MasterId)
        {
            //var RoleIds = _iMasterRoleService.GetAll()
            //    .Where(mr => mr.MasterId == MasterId)
            //    .Select(mr => mr.RolieId).ToList();
            var RoleIds = db.MasterRoles.ToList()
                .Where(ar => ar.Id == MasterId)
                .Select(ar => ar.RolieId).ToList();
            
            return Json(RoleIds, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrDelete(MasterRole model)
        {
            try
            {
                var masterRole = db.MasterRoles.ToList()
                    .Single(mr => mr.RolieId == model.RolieId && mr.MasterId == model.MasterId);
                db.MasterRoles.Remove(masterRole);
            }
            catch
            {
                db.MasterRoles.Add(model);
            }
            db.SaveChanges();

            return Content("Đã cập nhật vai trò");
        }
    }
}