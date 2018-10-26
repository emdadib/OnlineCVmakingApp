using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Interfaces
{
    public interface IEducationRepository : IRepository<Education>
    {
        IEnumerable<Education> GetAllWithPersonalBg();
        IEnumerable<Education> FindWithTraining(Func<Education, bool> predicate);
        //For Find Personal Details and Training
        IEnumerable<Education> FindWithPrdAndTraining(Func<Education, bool> predicate);
    }
}
