using OCVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCVM.Data
{
    public class DbInitialize
    {
        public static void Seed(OcvmContext context)
        {
            context.Database.EnsureCreated();
            //Data In PersonalDetail
            var PerDetail = new List<PersonalDetail>
            {
                new PersonalDetail
                {
                    FullName ="Md. Emdadul Islam",
                    FathersName ="Md. Nurul Islam",
                    MothersName ="Ayesha Begum",
                    DateOfBirth = DateTime.Parse("1993-03-12"),
                    Nationality ="Bangladesh", Religion="Islam"
                }
            };
            PerDetail.ForEach(x => context.PersonalDetail.Add(x));

            //Data In Education
            var Edu = new List<Education>
            {
                new Education
                {
                    Exam_Degree_Title ="Bachelor of Theoretical Islamic Studies",
                    Group_Major_Subject ="Hadith",
                    Institute_University ="Islamic University Bangladesh",
                    Result ="2nd Class",
                    CGPA = decimal.Parse("3.67"),
                    Scale = decimal.Parse("4.00"),
                    Year_Of_Passing = 2015,
                    Duration = 3,
                    Achievement = "PASS",
                    PersonalID = PerDetail.Single(x => x.FullName == "Md. Emdadul Islam").PersonalID
                }
            };
            Edu.ForEach(x => context.Educations.Add(x));

            //Data In Experience
            var Exp = new List<Experience>
            {
                new Experience
                {
                    Company_Name ="Data Soft Ltd.",
                    Company_Business ="Software Firm",
                    Designation ="Assit. Programmer",
                    Department =".NET",
                    start_Date = DateTime.Parse("2017-01-01"),
                    End_Date = DateTime.Parse("2018-01-05"),
                    Skill = "Developeing ASP.NET Based Application, Dekstop App, Web based Apps ",
                    PersonalID = PerDetail.Single(x => x.FullName == "Md. Emdadul Islam").PersonalID
                }
            };
            Exp.ForEach(x => context.Experiences.Add(x));

            //Data In Training
            var Trains = new List<Training>
            {
                new Training
                {
                    Training_Title ="ESAD-CS",
                    Country ="Bangladesh",
                    Topics_Covered ="Asp.Net Web Framework, Asp.net Dekstop App, Etc.",
                    Training_Year = 2018,
                    Institute = "IDB-BISEW",
                    Duration = "1 Year",
                    Location = "Chittagong",
                    PersonalID = PerDetail.Single(x => x.FullName == "Md. Emdadul Islam").PersonalID
                }
            };
            Trains.ForEach(x => context.Trainings.Add(x));
            context.SaveChanges();
        }
    }
}

