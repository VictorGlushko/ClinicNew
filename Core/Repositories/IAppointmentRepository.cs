using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Models;
using Clinic.Core.ViewModel;

namespace Clinic.Core.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentWithPatient(int id);
        IEnumerable<Appointment> GetAppointmentByDoctor(int id);

        IEnumerable<Appointment> GetTodaysAppointments(int id);
        IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate);

        IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel);
        bool ValidateAppointment(DateTime appntDate, int id);
        Appointment GetAppointment(int id);
        int CountAppointments(int id);
        void Add(Appointment appointment);
    }
}
