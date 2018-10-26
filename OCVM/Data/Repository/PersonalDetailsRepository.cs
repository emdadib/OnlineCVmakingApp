using Microsoft.EntityFrameworkCore;
using OCVM.Data.Interfaces;
using OCVM.Models;
using OCVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Repository
{
    public class PersonalDetailsRepository : Repository<PersonalDetail>, IPersonalDetailsRepository
    {
        public PersonalDetailsRepository(OcvmContext context) : base(context) { }
        public IEnumerable<PersonalDetail> GetPersonalDetails()
        {
            return context.PersonalDetail
                .Include(a => a.Educations)
                .Include(a => a.Experiences)
                .Include(a => a.Trainings)
                .Include(a => a.Contacts);
        }

        public PersonalDetail GetPersonal(int id)
        {
            return context.PersonalDetail.Where(a => a.PersonalID == id)
                
                .Include(a => a.Educations)
                .Include(a => a.Experiences)
                .Include(a => a.Trainings)
                .Include(a => a.Contacts)
                .FirstOrDefault();
        }

      
        public override void Delete(PersonalDetail entity)
        {
       
            var ToRemove = context.PersonalDetail.Where(b => b.Educations == entity && b.Experiences == entity && b.Trainings == entity);

            base.Delete(entity);

            context.PersonalDetail.RemoveRange(ToRemove);

            Save();
        }

       

       
    }
}
