using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using asc_general.Models;

namespace asc_general.Controllers
{
    public class HomeController : Controller
    {
       private DbAscEntities db = new DbAscEntities();

        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.cartoon = db.cartoons.ToList();
            return View(mymodel);
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
        public ActionResult Food()
        {
            ViewBag.Message = "foooooood";

            return View();
        }
        public ActionResult Cartoon()
        {
            ViewBag.Message = "cartoon";

            return View();
        }
  
    }
}