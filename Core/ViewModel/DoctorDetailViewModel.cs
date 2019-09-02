using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Core.Models;

namespace Clinic.Core.ViewModel
{
    public class DoctorDetailViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Appointment> UpcomingAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}