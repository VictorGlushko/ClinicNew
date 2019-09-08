using Clinic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    [Authorize]
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

        public ActionResult TotalAppointments()
        {
            var appointments = _context.Appointments.ToList();
            return Json(appointments.Count(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalUsers()
        {
            var users = _context.Users.ToList();
            return Json(users.Count(), JsonRequestBehavior.AllowGet);
        }

        //Today's patients
        public ActionResult TodaysPatients()
        {
            DateTime today = DateTime.Now.Date;
            var patients = _context.Patients.Where(p => p.DateTime >= today).ToList();
            return Json(patients.Count(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TodaysAppointments()
        {
            DateTime today = DateTime.Now.Date;
            var appointments = _context.Appointments
                .Where(a => a.StartDateTime >= today)
                .ToList();
            return Json(appointments.Count(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AvailableDoctors()
        {
            var doctors = _context.Doctors
                .Where(d => d.IsAvailable)
                .ToList();
            return Json(doctors.Count(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult ActiveAccounts()
        {
            var users = _context.Users
                .Where(u => u.IsActive == true)
                .ToList();
            return Json(users.Count(), JsonRequestBehavior.AllowGet);
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