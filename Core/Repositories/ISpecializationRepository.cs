using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Models;

namespace Clinic.Core.Repositories
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialization> GetSpecializations();
    }
}
