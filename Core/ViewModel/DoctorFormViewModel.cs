﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Clinic.Core.Models;
using Clinic.Models;

namespace Clinic.Core.ViewModel
{
    public class DoctorFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public bool IsAvailable { get; set; }


        [Required]
        public int Specialization { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }

    }
}