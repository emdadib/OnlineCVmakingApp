using OCVM.Data.Interfaces;
using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Repository
{
    public class ExperianceRepository : Repository<Experience>, IExperienceRepository
    {
        public ExperianceRepository(OcvmContext context) : base(context)
        {        
        }
        public override void Delete(Experience entity)
        {
            base.Delete(entity);
        }
    }
}
