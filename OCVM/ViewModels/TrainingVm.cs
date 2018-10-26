using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.ViewModels
{
    public class TrainingVm
    {
        public Training Training { get; set; }
        public IEnumerable<PersonalDetail> personalDetails { get; set; }
    }
}
