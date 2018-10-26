using OCVM.Data.Interfaces;
using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(OcvmContext _context) : base(_context)
        {
        }
    }
}
