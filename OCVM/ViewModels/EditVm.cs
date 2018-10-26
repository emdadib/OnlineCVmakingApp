using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCVM.Models;

namespace OCVM.ViewModels
{
    public class EditVm
    {
        public ICollection<PersonalDetail> PersonalDetail { get; set; }
        public ICollection<Education>  Education { get; set; }
        public ICollection<Experience> Experience { get; set; }
        public ICollection<Training> Training { get; set; }
        public ICollection<Contact>  Contact { get; set; }
    }
}
