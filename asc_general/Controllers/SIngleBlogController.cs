using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Dynamic;
using asc_general.Models;

namespace asc_general.Controllers
{
    public class SIngleBlogController : Controller
    {
        private DbAscEntities db = new DbAscEntities();
        // GET: SIngleBlog
        public ActionResult Index(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dynamic mymodel = new ExpandoObject();
            blog blg = db.blogs.Find(id);
            mymodel.myblog = db.blogs.ToList();
            mymodel.Blog = blg;
            mymodel.otherblogs = db.blogs.Where( o=> o.id != id && o.category_id == blg.category_id ).Take(3).ToList();
            return View(mymodel);
        }
    }
}