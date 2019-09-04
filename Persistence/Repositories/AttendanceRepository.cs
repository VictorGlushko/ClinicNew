using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Core.Models;
using Clinic.Core.Repositories;

namespace Clinic.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetAttandences()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Attendance> GetAttendance(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Attendance> GetPatientAttandences(string searchTerm = null)
        {
            throw new NotImplementedException();
        }

        public int CountAttendances(int id)
        {
            return _context.Attendances.Count(a => a.PatientId == id);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

    }
}