using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }
        public string Objective { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LinkdInUrl { get; set; }

        public string PermanentAddress { get; set; }
        public string presentAddress { get; set; }
        public string CurrentLocation { get; set; }
        public int ExpectedSalary { get; set; }
        public PersonalDetail PersonalDetail { get; set; }
        public int PersonalID { get; set; }
    }
}
