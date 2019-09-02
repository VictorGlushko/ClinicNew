using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.Core;
using Clinic.Core.ViewModel;

namespace Clinic.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: Appointments
        public ActionResult Index()
        {
           var appointmrnts =  _unitOfWork.Appointments.GetAppointments();

            return View(appointmrnts);
        }

        public ActionResult Create(int id)
        {
            var viewModel = new AppointmentFormViewModel
            {
                Patient = id,
                Doctors = _unitOfWork.Doctors.GetAvailableDoctors(),

                Heading = "New Appointment"
            };
            return View(viewModel);
        }

    }
}