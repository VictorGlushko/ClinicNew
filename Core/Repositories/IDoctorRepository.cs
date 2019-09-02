using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDoctors();
        IEnumerable<Doctor> GetAvailableDoctors();
        Doctor GetDoctor(int id);
        Doctor GetProfile(string userId);
        void Add(Doctor doctor);
    }
}
