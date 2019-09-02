using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
    }
}
