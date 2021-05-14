using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var toplam = context.Categories.Count().ToString();
            ViewBag.toplam = toplam;

            var result2 = context.Headings.Count(h => h.CategoryID == 15).ToString();
            ViewBag.result2 = result2;

            var result3 = context.Writers.Where(w => w.WriterName.Contains("a") || w.WriterName.Contains("A")).Count();
            ViewBag.result3 = result3;

            var result4 = context.Categories.Where(u => u.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.result4 = result4;

            var result5 = context.Categories.Where(c => c.CatergoryStatus == true).Count() -
                          context.Categories.Where(c => c.CatergoryStatus == false).Count();
            ViewBag.result5 = result5;

            return View();
        }
    }
}