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
    public class AttendancesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Attendances
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            var viewModel = new AttendanceFormViewModel
            {
                Patient = id,
                Heading = "Add Attendance"
            };
            return View("AttendanceForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(AttendanceFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("AttendanceForm", viewModel);

            var attendance = new Attendance
            {
                Id = viewModel.Id,
                ClinicRemarks = viewModel.ClinicRemarks,
                Diagnosis = viewModel.Diagnosis,
                SecondDiagnosis = viewModel.SecondDiagnosis,
                ThirdDiagnosis = viewModel.ThirdDiagnosis,
                Therapy = viewModel.Therapy,
                Date = DateTime.Now,
                Patient = _unitOfWork.Patients.GetPatient(viewModel.Patient)
            };
            _unitOfWork.Attandences.Add(attendance);
            _unitOfWork.Complete();
            //ViewBag.Confirm = "Successfully Saved";
            //return PartialView("_Confirmation");
            return RedirectToAction("Details", "Patients", new { id = viewModel.Patient });
        }

    }
}