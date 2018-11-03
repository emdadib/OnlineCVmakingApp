using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Models
{
    public class PersonalDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PersonalID { get; set; }
        [Required]
        [Display(Name ="Full Name")]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string UserPicture { get; set; }
        public string Gender { get; set; }
        public  ICollection<Education> Educations { get; set; }
        public  ICollection<Training> Trainings { get; set; }
        public  ICollection<Experience> Experiences { get; set; }
        public  ICollection<Contact>  Contacts { get; set; }
    }
}
