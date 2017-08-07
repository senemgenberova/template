using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asc_general.Models;
using System.Dynamic;
using System.Net;
using PagedList;

namespace asc_general.Controllers.Controllers
{
    public class ComplexController : Controller
    {
        private DbAscEntities db = new DbAscEntities();
        
        // GET: Complex
        public ActionResult Index(int? id,int? regionID)
        {   
            if (id == null || regionID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dynamic mymodel = new ExpandoObject();
            our_complex complex_id = db.our_complex.Find(id);
            mymodel.complexId = complex_id;
            mymodel.regions = db.regions.ToList();
            mymodel.allKindergarten = db.our_complex.Where(c => c.region_id == complex_id.region_id && c.edu_or_gym==complex_id.edu_or_gym).ToList();
            mymodel.next = db.our_complex.FirstOrDefault(n => n.id > complex_id.id && n.region_id == complex_id.region_id && n.edu_or_gym == complex_id.edu_or_gym);
            mymodel.prev = db.our_complex.OrderByDescending(o => o.id).FirstOrDefault(p => p.id < complex_id.id && p.region_id == complex_id.region_id && p.edu_or_gym == complex_id.edu_or_gym);

            return View(mymodel);
        }

        public ActionResult allComplex(int? id,bool? complexType)
        {
            if(id == null || complexType == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dynamic data = new ExpandoObject();
            data.Region = db.regions.Find(id);
            data.otherRegions = db.regions.Where(r => r.id != id).ToList();
            data.kindergardenByRegion = db.our_complex.Where(c => c.region_id == id && c.edu_or_gym == complexType).ToList();
            data.kindergardenType = db.our_complex.Where(c => c.region_id == id && c.edu_or_gym == complexType).FirstOrDefault();
            return View(data);
        }

    }
}