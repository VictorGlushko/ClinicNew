using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.Core.ViewModel
{
    public class AppointmentSearchVM
    {
        public string Name { get; set; }
        public string Option { get; set; }
        public DateTime Date { get; set; }
    }
}