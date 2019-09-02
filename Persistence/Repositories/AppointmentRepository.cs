using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Core;
using Clinic.Core.Models;
using System.Data.Entity;
using Clinic.Core.Repositories;

namespace Clinic.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _context.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToList();
        }

        public IEnumerable<Appointment> GetAppointmentWithPatient(int id)
        {
            return _context.Appointments
                .Where(p => p.PatientId == id)
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToList();
        }

        public IEnumerable<Appointment> GetAppointmentByDoctor(int id)
        {
            return _context.Appointments
                .Where(d => d.DoctorId == id)
                .Include(p => p.Patient)
                .ToList();
        }

        public IEnumerable<Appointment> GetTodaysAppointments(int id)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Appointments
                .Where(d => d.DoctorId == id && d.StartDateTime >= today)
                .Include(p => p.Patient)
                .OrderBy(d => d.StartDateTime)
                .ToList();
        }


        public bool ValidateAppointment(DateTime appntDate, int id)
        {
            return _context.Appointments.Any(a => a.StartDateTime == appntDate && a.DoctorId == id);
        }

        public Appointment GetAppointment(int id)
        {
            return _context.Appointments.Find(id);
        }

        public int CountAppointments(int id)
        {
            return _context.Appointments.Count(a => a.PatientId == id);
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }
    }
}