using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.ViewModels
{
    public class SearchVm
    {
       public IEnumerable<Experience> Experiences { get; set; }
       public string Text { get; set; }
    }
}
