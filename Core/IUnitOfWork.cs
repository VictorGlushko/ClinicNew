using Clinic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core
{
   public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        ICityRepository Cities { get; }

        IDoctorRepository Doctors { get; }
        IAttendanceRepository Attandences { get; }

        ISpecializationRepository Specialization { get; }
        IAppointmentRepository Appointments { get; }

        void Complete();
    }
}
