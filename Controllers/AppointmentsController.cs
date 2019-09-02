using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.Core;
using Clinic.Core.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel.Doctors = _unitOfWork.Doctors.GetAvailableDoctors();
                return View(viewModel);

            }

            var appointment = new Appointment()
            {
                StartDateTime = viewModel.GetStartDateTime(),
                Detail = viewModel.Detail,
                Status = false,
                PatientId = viewModel.Patient,
                Doctor = _unitOfWork.Doctors.GetDoctor(viewModel.Doctor)

            };

            if (_unitOfWork.Appointments.ValidateAppointment(appointment.StartDateTime, viewModel.Doctor))
                return View("InvalidAppointment");

            _unitOfWork.Appointments.Add(appointment);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Appointments");
        }

        public ActionResult Edit(int id)
        {
            var appointment = _unitOfWork.Appointments.GetAppointment(id);
            var viewModel = new AppointmentFormViewModel()
            {
                Heading = "New Appointment",
                Id = appointment.Id,
                Date = appointment.StartDateTime.ToString("dd/MM/yyyy"),
                Time = appointment.StartDateTime.ToString("HH:mm"),
                Detail = appointment.Detail,
                Status = appointment.Status,
                Patient = appointment.PatientId,
                Doctor = appointment.DoctorId,
                //Patients = _unitOfWork.Patients.GetPatients(),
                Doctors = _unitOfWork.Doctors.GetDoctors()
            };
            return View(viewModel);
        }
    }
}