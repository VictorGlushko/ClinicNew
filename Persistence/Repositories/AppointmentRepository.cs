using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Core;
using Clinic.Core.Models;
using System.Data.Entity;
using Clinic.Core.Repositories;
using Clinic.Core.ViewModel;

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

        public IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate)
        {
            return _context.Appointments.Where(a => DbFunctions.DiffDays(a.StartDateTime, getDate) == 0)
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
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

        public IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel)
        {
            var result = _context.Appointments.Include(p => p.Patient).Include(d => d.Doctor).AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Name))
                    result = result.Where(a => a.Doctor.Name == searchModel.Name);
                if (!string.IsNullOrWhiteSpace(searchModel.Option))
                {
                    if (searchModel.Option == "ThisMonth")
                    {
                        result = result.Where(x => x.StartDateTime.Year == DateTime.Now.Year && x.StartDateTime.Month == DateTime.Now.Month);
                    }
                    else if (searchModel.Option == "Pending")
                    {
                        result = result.Where(x => x.Status == false);
                    }
                    else if (searchModel.Option == "Approved")
                    {
                        result = result.Where(x => x.Status);
                    }
                }
            }

            return result;
        }
    }
}