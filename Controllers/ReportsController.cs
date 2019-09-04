using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DaillyAppointments()
        {
            //var daily = _unitOfWork.Appointments.GetAppointments();
            return View();
        }
    }
}