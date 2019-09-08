using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.Core;
using Clinic.Core.ViewModel;

namespace Clinic.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DaillyAppointments()
        {
            var daily = _unitOfWork.Appointments.GetAppointments();
            return View(daily);
        }

        public ActionResult Dailly(DateTime getDate)
        {
            var dailyAppointments = _unitOfWork.Appointments.GetDaillyAppointments(getDate);
            return View("_DailyAppointments", dailyAppointments);
        }

        public ActionResult Appointments()
        {
            var appointments = _unitOfWork.Appointments.GetAppointments();
            return View(appointments);
        }


        public ActionResult TestAppointment(AppointmentSearchVM viewModel)
        {
            var filter = _unitOfWork.Appointments.FilterAppointments(viewModel);
            return PartialView("_Appointments",filter);
        }


        public ActionResult Attandences()
        {
            var attandences = _unitOfWork.Attandences.GetAttandences();
            return View(attandences);
        }
        public ActionResult PatientAttandence(string token = null)
        {
            var patientAttandences = _unitOfWork.Attandences.GetPatientAttandences(token);
            return View("_AttandencePartial", patientAttandences);
        }
    }
}