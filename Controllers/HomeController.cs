using Clinic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TotalDoctors()
        {
            var doctors = _context.Doctors.ToList();
            var jsonobj = Json(doctors.Count(), JsonRequestBehavior.AllowGet);

            return jsonobj;
        }

        public ActionResult TotalPatients()
        {
            var pations = _context.Patients.ToList();
            var jsonobj = Json(pations.Count, JsonRequestBehavior.AllowGet);
            return jsonobj;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}