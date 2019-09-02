using Clinic.Core.Models;
using Clinic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Clinic.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        public Patient GetPatient(int id)
        {
            var patient = _context.Patients.Include(c => c.Cities).SingleOrDefault(p => p.Id == id);
            return patient;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.Include(c => c.Cities);
        }

        public IEnumerable<Patient> GetRecentPatients()
        {
            return _context.Patients
              .Where(a => DbFunctions.DiffDays(a.DateTime, DateTime.Now) == 0)
              .Include(c => c.Cities);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);

        }
    }
}