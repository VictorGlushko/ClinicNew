using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Core.Models;
using System.Data.Entity;
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
            return _context.Attendances.ToList();
        }

        public IEnumerable<Attendance> GetAttendance(int id)
        {
            return _context.Attendances.Where(p => p.PatientId == id).ToList();
        }

        public IEnumerable<Attendance> GetPatientAttandences(string searchTerm = null)
        {
            var attandences = _context.Attendances.Include(p => p.Patient);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                attandences = attandences.Where(p => p.Patient.Token.Contains(searchTerm));
            }
            return attandences.ToList();
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