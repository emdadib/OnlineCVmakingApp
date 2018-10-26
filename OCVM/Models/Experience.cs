using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Models
{
    public class Experience
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ExperienceID { get; set; }
        public string Company_Name { get; set; }
        public string Company_Business { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> start_Date { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> End_Date { get; set; }
        public string Skill { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }
        public int PersonalID { get; set; }
    }
}
