using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Clinic.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Clinic.Persistence
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}