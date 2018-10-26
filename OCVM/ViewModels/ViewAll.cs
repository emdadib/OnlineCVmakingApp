using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.ViewModels
{
    public class ViewAll
    {
        public int PersonalID { get; set; }
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
        //
        public int TrainingID { get; set; }
        public string Training_Title { get; set; }
        public string Country { get; set; }
        public string Topics_Covered { get; set; }
        public Nullable<int> Training_Year { get; set; }
        public string Institute { get; set; }
        public string Duration { get; set; }
        public string Location { get; set; }

        //
        public int ExperienceID { get; set; }
        public string Company_Name { get; set; }
        public string Company_Business { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public string Skill { get; set; }
        //
        public string Exam_Degree_Title { get; set; }
        public string Group_Major_Subject { get; set; }
        public string Institute_University { get; set; }
        public string Result { get; set; }
        public Nullable<decimal> CGPA { get; set; }
        public Nullable<decimal> Scale { get; set; }
        public Nullable<int> Year_Of_Passing { get; set; }
        public Nullable<int> EduDuration { get; set; }
        public string Achievement { get; set; }
        //
        public int ContactID { get; set; }
        public string Objective { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LinkdInUrl { get; set; }
        public string PermanentAddress { get; set; }
        public string presentAddress { get; set; }
        public string CurrentLocation { get; set; }
        public int ExpectedSalary { get; set; }
    }
}
