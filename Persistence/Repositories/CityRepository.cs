using Clinic.Core.Models;
using Clinic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }

    }
}