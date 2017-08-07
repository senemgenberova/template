using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using System.Dynamic;
using System.Net;

namespace asc_general.Controllers
{
    public class gymblogController : Controller
    {
        private DbAscEntities db = new DbAscEntities();
        // GET: gym_blog
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dynamic mymodel = new ExpandoObject();
            gym_blog gym_id = db.gym_blog.Find(id);
            mymodel.gym_blog = gym_id;
            return View(mymodel);
        }
    }
}