using Clinic.Core;
using Clinic.Core.Models;
using Clinic.Core.ViewModel;
using Clinic.Persistence;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class PatientsController : Controller
    {


        IUnitOfWork _unitOfWork;
        public PatientsController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _unitOfWork = ninjectKernel.Get<IUnitOfWork>();

        }
        // GET: Patients
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult Details(int id)
        {

            var viewModel = new PatientDetailViewModel()
            {
                Patient = _unitOfWork.Patients.GetPatient(id),
                 Appointments = _unitOfWork.Appointments.GetAppointmentWithPatient(id),
                //  Attendances = _unitOfWork.Attandences.GetAttendance(id),
                  CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
                  CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
            };



            return View("Details", viewModel);
        }

        public ActionResult Create(PatientFormViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                return View("PatientForm", viewModel);

            }

            var patient = new Patient
            {
                Name = viewModel.Name,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                DateTime = DateTime.Now,
                BirthDate = viewModel.GetBirthDate(),
                Height = viewModel.Height,
                Weight = viewModel.Weight,
                CityId = viewModel.City,
                Sex = viewModel.Sex,
                Token = (2018 + _unitOfWork.Patients.GetPatients().Count()).ToString().PadLeft(7, '0')
            };

            _unitOfWork.Patients.Add(patient);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Patients");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PatientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                return View("PatientForm", viewModel);
            }


            var patientInDb = _unitOfWork.Patients.GetPatient(viewModel.Id);
            patientInDb.Id = viewModel.Id;
            patientInDb.Name = viewModel.Name;
            patientInDb.Phone = viewModel.Phone;
            patientInDb.BirthDate = viewModel.GetBirthDate();
            patientInDb.Address = viewModel.Address;
            patientInDb.Height = viewModel.Height;
            patientInDb.Weight = viewModel.Weight;
            patientInDb.Sex = viewModel.Sex;
            patientInDb.CityId = viewModel.City;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Patients");
        }

        public ActionResult Edit(int id)
        {
            var patient = _unitOfWork.Patients.GetPatient(id);

            var viewModel = new PatientFormViewModel
            {
                Heading = "Edit Patient",
                Id = patient.Id,
                Name = patient.Name,
                Phone = patient.Phone,
                Date = patient.DateTime,
                //Date = patient.DateTime.ToString("d MMM yyyy"),
                BirthDate = patient.BirthDate.ToString("dd/MM/yyyy"),
                Address = patient.Address,
                Height = patient.Height,
                Weight = patient.Weight,
                Sex = patient.Sex,
                City = patient.CityId,
                Cities = _unitOfWork.Cities.GetCities()
            };
            return View("PatientForm", viewModel);
        }
    }
}