using Clinic.Core.Models;
using Clinic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Clinic.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors
                   .Include(s => s.Specialization)
                   .Include(u => u.Physician)
                   .ToList();
        }


        public IEnumerable<Doctor> GetAvailableDoctors()
        {
            return  _context.Doctors.Where(d => d.IsAvailable == true)
                    .Include(s => s.Specialization)
                    .Include(u => u.Physician)
                    .ToList();

        }

        public Doctor GetDoctor(int id)
        {
            var doctor =    _context.Doctors
                            .Include(s => s.Specialization)
                            .Include(u => u.Physician)
                            .SingleOrDefault(d => d.Id == id);

            return doctor;


        }

        public Doctor GetProfile(string userId)
        {
            return _context.Doctors
             .Include(s => s.Specialization)
             .Include(u => u.Physician)
             .SingleOrDefault(d => d.PhysicianId == userId);
        }


        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }


    }
}