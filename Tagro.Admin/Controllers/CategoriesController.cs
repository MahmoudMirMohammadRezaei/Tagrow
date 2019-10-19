using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tagro.Data.Data;

namespace Tagro.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.Parent);
            return View(categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            //ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name");
            
            using (MyDbContext ctx = new MyDbContext())
            {
                var categories = ctx.Categories.ToList();
                ViewBag.Categories = categories;
            }

            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParentId,CreatedDate,UpdatedDate,Status,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == 0)
                {
                    category.ParentId = null;
                }
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            using (MyDbContext ctx = new MyDbContext())
            {
                var categories = ctx.Categories.ToList();
                ViewBag.Categories = categories;
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            using (MyDbContext ctx = new MyDbContext())
            {
                var categories = ctx.Categories.ToList();
                ViewBag.Categories = categories;

                Category Category = ctx.Categories.FirstOrDefault(m => m.Id == id);
                ViewBag.CategoryId = Category.ParentId;
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParentId,CreatedDate,UpdatedDate,Status,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == 0)
                {
                    category.ParentId = null;
                }
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name", category.ParentId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);

            category.Status = (int)Status.deleted;

            if (category != null)
            {
                db.Entry(category).State = EntityState.Modified;
                //ctx.Entry(attendance).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }

            //db.Categories.Remove(category);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        public enum Status
        {
            active = 1,
            deleted = 2,
            passive = 3
        }
    }
}
