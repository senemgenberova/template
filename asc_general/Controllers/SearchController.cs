using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using PagedList;

namespace asc_general.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private DbAscEntities db = new DbAscEntities();
        public ActionResult Index(int? page, string searchString)
        {
            int pageNumber = page ?? 1;
            ViewBag.searchStr = searchString;
            if (page == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                int count = db.blogs.Where(b => b.title.Contains(searchString)).Count();
                ViewBag.ResultCount = count;
                if (count != 0)
                {
                    ViewBag.Searching = db.blogs.Where(b => b.title.Contains(searchString)).OrderBy(o => o.id).ToPagedList(pageNumber, 3);
                }
                else {
                    ViewBag.NoResult = "Nəticə tapılmadı";
                    page = 1;
                }

            }
            else {
                ViewBag.EmptyString = "Nəticə tapılmadı";
                page = 1;
            }
            return View();
        }

        [HttpPost]
        public JsonResult Autocomplete(string searchString) {
            var titles = db.blogs.Where(b => b.title.Contains(searchString)).OrderBy(o => o.id).Select(b=>b.title).ToList();
            return Json(titles, JsonRequestBehavior.AllowGet);
        }
    }
}