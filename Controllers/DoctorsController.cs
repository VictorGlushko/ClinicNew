using Clinic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.Core.ViewModel;

namespace Clinic.Controllers
{
    public class DoctorsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public DoctorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Doctors
        public ActionResult Index()
        {
            var doctors = _unitOfWork.Doctors.GetDoctors();
            return View(doctors);
        }
        public ActionResult Details(int id)
        {
            var viewModel = new DoctorDetailViewModel
            {
                Doctor = _unitOfWork.Doctors.GetDoctor(id),
                UpcomingAppointments = _unitOfWork.Appointments.GetTodaysAppointments(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentByDoctor(id),
            };

            return View(viewModel);
        }

    }
}