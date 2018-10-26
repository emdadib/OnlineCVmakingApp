using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCVM.Models;

namespace OCVM.ViewModels
{
    public class ExperianceVm
    {
        public Experience Experience { get; set; }
        public IEnumerable<PersonalDetail> personalDetails { get; set; }
    }
}
