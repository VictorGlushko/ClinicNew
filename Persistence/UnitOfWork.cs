using Clinic.Core;
using Clinic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Core.Models;
using Clinic.Persistence.Repositories;

namespace Clinic.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPatientRepository Patients { get; private set; }

        public ICityRepository Cities { get; private set; }
                
        public IDoctorRepository Doctors { get; private set; }
        public IAttendanceRepository Attandences { get; }
        public ISpecializationRepository Specialization { get; private set; }
        public IAppointmentRepository Appointments { get; }
        public IApplicationUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context    = context;
            Patients    = new PatientRepository(context);
            Doctors     = new DoctorRepository(context);
            Appointments = new AppointmentRepository(context);
            Specialization = new SpecializationRepository(context);
            Cities      = new CityRepository(context);
            Attandences = new AttendanceRepository(context);
            Users = new ApplicationUserRepository(context);
        }



        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}