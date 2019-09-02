using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients();
        IEnumerable<Patient> GetRecentPatients();
        //IEnumerable<Patient> GetPatientByToken(string searchTerm = null);
        Patient GetPatient(int id);
        //IQueryable<Patient> GetPatientQuery(string query);
        void Add(Patient patient);
        void Remove(Patient patient);
    }
}
