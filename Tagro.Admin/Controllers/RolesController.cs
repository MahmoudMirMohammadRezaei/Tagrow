using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tagro.Data.Data;

namespace Tagro.Admin.Controllers
{
    //[Authorize("Admin")]
    public class RolesController : Controller
    {
        // GET: AspNetRoles
        public ActionResult Index()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                List<AspNetRole> roles = ctx.AspNetRoles.ToList();

                return View(roles);
            }
        }

        public ActionResult Form(string id = null)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                AspNetRole role;

                if (id == null)
                {
                    role = new AspNetRole()
                    {
                        Id = null
                    };
                }
                else
                {
                    role = ctx.AspNetRoles.FirstOrDefault(m => m.Id == id);
                }

                if (role == null)
                {
                    return RedirectToAction("Index");
                }

                return View(role);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Form(AspNetRole role)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                if (role == null)
                {
                    return RedirectToAction("Index");
                }

                if (role.Id == null)
                {
                    role.Id = Guid.NewGuid().ToString();

                    ctx.Entry(role).State = System.Data.Entity.EntityState.Added;
                }
                else
                {
                    ctx.Entry(role).State = System.Data.Entity.EntityState.Modified;
                }

                ctx.SaveChanges();

                return RedirectToAction("Index");

            }
        }


        //public ActionResult UpdateStatus(int? id, byte status)
        //{
        //    using (MyDbContext ctx = new MyDbContext())
        //    {
        //        Report role = ctx.Reports.FirstOrDefault(m => m.Id == id);

        //        if (role != null)
        //        {
        //            role.Status = status;

        //            ctx.SaveChanges();
        //        }

        //        return RedirectToAction("Index");

        //    }
        //}


        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (MyDbContext ctx = new MyDbContext())
            {
                AspNetRole aspNetRole = ctx.AspNetRoles.FirstOrDefault(m => m.Id == id);

                if (aspNetRole != null)
                {
                    ctx.Entry(aspNetRole).State = System.Data.Entity.EntityState.Deleted;
                }

            return View(aspNetRole);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {


            using (MyDbContext ctx = new MyDbContext())
            {
                AspNetRole aspNetRole = ctx.AspNetRoles.FirstOrDefault(m => m.Id == id);

                if (aspNetRole != null)
                {
                    ctx.Entry(aspNetRole).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }




        //public enum Status
        //{
        //    active = 1,
        //    deleted = 2,
        //}

    }
}