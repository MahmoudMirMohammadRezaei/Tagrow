using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tagro.Data.Data;
using static TagroReport.Controllers.ReportController;

namespace TagroReport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                List<Report> reports = ctx.Reports.Include("ImageNews")
                                                  .Include("Category")
                                                  .Include("AspNetUser")
                                                  .Where(m => m.Status == (byte)Status.published)                                                  
                                                  .ToList();

                var imageNews = ctx.ImageNews.ToList();
                return View(reports);
            }
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
    }
}