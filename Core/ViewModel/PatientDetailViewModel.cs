﻿using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.Core.ViewModel
{
    public class PatientDetailViewModel
    {
        public Patient Patient { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public int CountAppointments { get; set; }
        public int CountAttendance { get; set; }
    }
}