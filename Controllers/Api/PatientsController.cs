using AutoMapper;
using Clinic.Core;
using Clinic.Core.Dto;
using Clinic.Core.Models;
using Clinic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Clinic.Controllers.Api
{
    public class PatientsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
   


        // GET: Patients
        public IHttpActionResult GetPatients()
        {
            var patientsQuery = _unitOfWork.Patients.GetPatients();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDto>());
            var mapper = new Mapper(config);

            var patientDto = patientsQuery.ToList().Select(mapper.Map<Patient, PatientDto>);

            return Ok(patientsQuery);

        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var patient = _unitOfWork.Patients.GetPatient(id);
          //  _unitOfWork.Patients.Remove(patient);
            _unitOfWork.Complete();
            return Ok();
        }


    }
}
