using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tagro.Data;
using Tagro.Data.Data;

namespace TagroReport.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                string userId = User.Identity.GetUserId();

                List<Report> reports = ctx.Reports
                            //.Where(m => m.Status == (byte)Status.published && m.UserId == userId)
                            .Where(m => m.UserId == userId)
                            .ToList();
                return View(reports);
            }
        }

        public ActionResult Form(int? id = null)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Report report;
                if (id == null)
                {
                    report = new Report()
                    {
                        CreatedDate = DateTime.Now,
                        Status = 1,
                    };

                }
                else
                {
                    report = ctx.Reports.Include("Category").FirstOrDefault(m => m.Id == id);
                }

                if (report == null)
                {
                    return RedirectToAction("Index");
                }

                var categories = ctx.Categories.ToList();
                ViewBag.Categories = categories;


                return View(report);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize]

        public ActionResult Form(Report report, HttpPostedFileBase file)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                if (report == null)
                {
                    return RedirectToAction("Index");
                }

                string userId = User.Identity.GetUserId();

                report.UserId = userId;

                var categories = ctx.Categories.ToList();
                ViewBag.Categories = categories;

                if (report.Id == 0)
                {
                    if (report.CategoryId == 0)
                    {
                        report.CategoryId = null;
                    }
                    report.CreatedDate = DateTime.Now;
                    report.UpdatedDate = DateTime.Now;
                    report.Status = (byte)Status.hold;
                    ctx.Entry(report).State = System.Data.Entity.EntityState.Added;
                    ctx.SaveChanges();

                    string ImgPath = "";
                    if (file != null)
                    {
                        ImgPath = Addfile(file, "~/Files/banners");

                        ImageNew imageNew = new ImageNew();
                        imageNew.NewsId = report.Id;
                        imageNew.Path = ImgPath;
                        report.Status = (byte)Status.hold;
                        ctx.Entry(imageNew).State = System.Data.Entity.EntityState.Added;
                        report.ImageId = imageNew.Id;
                    }

                    ctx.SaveChanges();

                }
                else
                {
                    if (report.CategoryId == 0)
                    {
                        report.CategoryId = null;
                    }
                    report.UpdatedDate = DateTime.Now;
                    ctx.Entry(report).State = System.Data.Entity.EntityState.Modified;

                    string ImgPath = "";
                    if (file != null)
                    {
                        ImgPath = Addfile(file, "~/Files/banners");
                        ImageNew imageNew = new ImageNew();
                        imageNew.NewsId = report.Id;
                        imageNew.Path = ImgPath;
                        ctx.Entry(imageNew).State = System.Data.Entity.EntityState.Added;
                        report.ImageId = imageNew.Id;
                    }


                    ctx.SaveChanges();
                }

                ctx.SaveChanges();

                return RedirectToAction("Index");

            }
        }


        public ActionResult UpdateStatus(int id, byte status)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Report report = ctx.Reports.FirstOrDefault(m => m.Id == id);

                if (report != null)
                {
                    report.Status = status;

                    ctx.SaveChanges();
                }

                return RedirectToAction("Index");

            }
        }

        // GET: Reports/Details/5
        public ActionResult Details(int id)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Report report = ctx.Reports.FirstOrDefault(m => m.Id == id);
                Category category = ctx.Categories.FirstOrDefault(m => m.Id == report.CategoryId);

                var categories = ctx.Categories.Where(m => m.Categories == report.Category);
                ViewBag.Categories = categories;

                var userName = ctx.AspNetUsers.FirstOrDefault(m => m.Id == report.UserId);
                if (userName != null)
                {
                    string username = userName.Email;
                    ViewBag.userName = username;
                }


                return View(report);

            }
        }


        public static string create_directory(string path)
        {
            try
            {
                if (!(Directory.Exists(path)))
                    Directory.CreateDirectory(path);
                return "با موفقیت ایجاد شد";
            }
            catch (Exception e)
            {
                return "مشکلی در روند ایجاد کردن فولدر پیش آمده ، بعدا دوباره امتحان کنید";
                throw;
            }
        }


        public string Addfile(HttpPostedFileBase file, string path)
        {
            var GuidName = Guid.NewGuid().ToString();
            //string pic = System.IO.Path.GetFileName(GuidName + file.FileName);
            var ext = Path.GetExtension(file.FileName);


            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var imagepath = Path.Combine(Server.MapPath(path), GuidName + ext);
                file.SaveAs(imagepath);
            }

            return GuidName + ext;
        }



        public enum Status
        {
            published = 1,
            deleted = 2,
            rejected = 3,
            hold = 4
        }

    }
}