using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.ViewModels
{
    public class ExpViewModels
    {
        public int ExperienceID { get; set; }
        public string Company_Name { get; set; }
        public string Company_Business { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
 
        public Nullable<System.DateTime> start_Date { get; set; }
      
        public Nullable<System.DateTime> End_Date { get; set; }
        public string Skill { get; set; }
       
        public int PersonalID { get; set; }
    }
}
