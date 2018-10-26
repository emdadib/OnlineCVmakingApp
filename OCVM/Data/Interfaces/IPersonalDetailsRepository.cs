using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Interfaces
{
    public interface IPersonalDetailsRepository : IRepository<PersonalDetail>
    {
        IEnumerable<PersonalDetail> GetPersonalDetails();
        PersonalDetail GetPersonal(int id);
    }
}
