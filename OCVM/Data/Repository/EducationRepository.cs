using Microsoft.EntityFrameworkCore;
using OCVM.Data.Interfaces;
using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Repository
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        public EducationRepository(OcvmContext context) : base(context) { }

        public IEnumerable<Education> FindWithTraining(Func<Education, bool> predicate)
        {
            return context.Educations
                .Include(a => a.TrainingDetails)
                .Where(predicate);
        }

        public IEnumerable<Education> FindWithPrdAndTraining(Func<Education, bool> predicate)
        {
            return context.Educations
                .Include(a => a.PersonalDetail)
                .Include(a => a.TrainingDetails)
                .Where(predicate);
        }

        public IEnumerable<Education> GetAllWithPersonalBg()
        {
            return context.Educations.Include(a => a.PersonalDetail);
        }



       
    }
}
