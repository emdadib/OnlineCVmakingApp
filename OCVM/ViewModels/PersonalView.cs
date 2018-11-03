using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.ViewModels
{
    public class PersonalView
    {
        public int PersonalID { get; set; }
        public string FullName { get; set; }
        public string UserPicture { get; set; }
        public string Skill { get; set; }
        public string Objective { get; set; }
        public string Designation { get; set; }
        public string CurrentLocation { get; set; }
        public int ExpectedSalary { get; set; }
        public string Exam_Degree_Title { get; set; }
        public string Training_Title { get; set; }

    }
}
