using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic.Core.Models;
using Clinic.Core.Repositories;

namespace Clinic.Persistence.Repositories
{
    public class SpecializationRepository:ISpecializationRepository
    {
        public readonly ApplicationDbContext Context;

        public SpecializationRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            return Context.Specializations.ToList();
        }
    }
}