﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCVM.Data.Interfaces;
using OCVM.ViewModels;
using Rotativa.AspNetCore;

namespace OCVM.Controllers
{
    public class CvViewController : Controller
    {
        private readonly IPersonalDetailsRepository detailsRepository;
        private readonly IEducationRepository  educationRepository;
        private readonly IExperienceRepository   experienceRepository;
        private readonly ITrainingRepository    trainingRepository;
        private readonly IContactRepository     contactRepository;
        
        public CvViewController(IPersonalDetailsRepository _detailsRepository, IEducationRepository _educationRepository, IContactRepository contact, IExperienceRepository _experienceRepository, ITrainingRepository _trainingRepository)
        {
            detailsRepository = _detailsRepository;
            educationRepository = _educationRepository;
            experienceRepository = _experienceRepository;
            trainingRepository = _trainingRepository;
            contactRepository = contact;
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            List<ViewAll> ab = detailsRepository.GetPersonalDetails().Where(a => a.PersonalID == id).Select(b => new ViewAll
            {
                FullName = b.FullName,
                FathersName = b.FathersName,
                MothersName = b.MothersName,
                DateOfBirth = b.DateOfBirth,
                Religion = b.Religion,
                Nationality = b.Nationality,
                MaritalStatus = b.MaritalStatus,
                Gender = b.Gender,
                UserPicture = b.UserPicture,
                //
                Training_Title = b.Trainings.Select(a => a.Training_Title).SingleOrDefault(),
                Country = b.Trainings.Select(a => a.Country).SingleOrDefault(),
                Topics_Covered = b.Trainings.Select(a => a.Topics_Covered).SingleOrDefault(),
                Training_Year = b.Trainings.Select(a => a.Training_Year).SingleOrDefault(),
                Institute = b.Trainings.Select(a => a.Institute).SingleOrDefault(),
                Duration = b.Trainings.Select(a => a.Duration).SingleOrDefault(),
                Location = b.Trainings.Select(a => a.Location).SingleOrDefault(),
                //
                Company_Name = b.Experiences.Select(a => a.Company_Name).SingleOrDefault(),
                Company_Business = b.Experiences.Select(a => a.Company_Business).SingleOrDefault(),
                Designation = b.Experiences.Select(a => a.Designation).SingleOrDefault(),
                Department = b.Experiences.Select(a => a.Department).SingleOrDefault(),
                start_Date = b.Experiences.Select(a => a.start_Date).SingleOrDefault(),
                End_Date = b.Experiences.Select(a => a.End_Date).SingleOrDefault(),
                Skill = b.Experiences.Select(a => a.Skill).SingleOrDefault(),
                //
                Exam_Degree_Title = b.Educations.Select(a => a.Exam_Degree_Title).SingleOrDefault(),
                Group_Major_Subject = b.Educations.Select(a => a.Group_Major_Subject).SingleOrDefault(),
                Institute_University = b.Educations.Select(a => a.Institute_University).SingleOrDefault(),
                Result = b.Educations.Select(a => a.Result).SingleOrDefault(),
                CGPA = b.Educations.Select(a => a.CGPA).SingleOrDefault(),
                Scale = b.Educations.Select(a => a.Scale).SingleOrDefault(),
                Year_Of_Passing = b.Educations.Select(a => a.Year_Of_Passing).SingleOrDefault(),
                EduDuration = b.Educations.Select(a => a.Duration).SingleOrDefault(),
                Achievement = b.Educations.Select(a => a.Achievement).SingleOrDefault(),
                //
                Objective = b.Contacts.Select(a => a.Objective).SingleOrDefault(),
                PhoneNumber = b.Contacts.Select(a => a.PhoneNumber).SingleOrDefault(),
                Email = b.Contacts.Select(a => a.Email).SingleOrDefault(),
                LinkdInUrl = b.Contacts.Select(a => a.LinkdInUrl).SingleOrDefault(),
                PermanentAddress = b.Contacts.Select(a => a.PermanentAddress).SingleOrDefault(),
                presentAddress = b.Contacts.Select(a => a.presentAddress).SingleOrDefault(),
                CurrentLocation = b.Contacts.Select(a => a.CurrentLocation).SingleOrDefault(),
                ExpectedSalary = b.Contacts.Select(a => a.ExpectedSalary).SingleOrDefault(),

            }).ToList();


            return View(ab);
        }
        public IActionResult Pdf(int id)
        {
            List<ViewAll> ab = detailsRepository.GetPersonalDetails().Where(a => a.PersonalID == id).Select(b => new ViewAll
            {
                PersonalID = b.PersonalID,
                FullName = b.FullName,
                FathersName = b.FathersName,
                MothersName = b.MothersName,
                DateOfBirth = b.DateOfBirth,
                Religion = b.Religion,
                Nationality = b.Nationality,
                MaritalStatus = b.MaritalStatus,
                Gender = b.Gender,
                UserPicture = b.UserPicture,
                //
                Training_Title = b.Trainings.Select(a => a.Training_Title).SingleOrDefault(),
                Country = b.Trainings.Select(a => a.Country).SingleOrDefault(),
                Topics_Covered = b.Trainings.Select(a => a.Topics_Covered).SingleOrDefault(),
                Training_Year = b.Trainings.Select(a => a.Training_Year).SingleOrDefault(),
                Institute = b.Trainings.Select(a => a.Institute).SingleOrDefault(),
                Duration = b.Trainings.Select(a => a.Duration).SingleOrDefault(),
                Location = b.Trainings.Select(a => a.Location).SingleOrDefault(),
                //
                Company_Name = b.Experiences.Select(a => a.Company_Name).SingleOrDefault(),
                Company_Business = b.Experiences.Select(a => a.Company_Business).SingleOrDefault(),
                Designation = b.Experiences.Select(a => a.Designation).SingleOrDefault(),
                Department = b.Experiences.Select(a => a.Department).SingleOrDefault(),
                start_Date = b.Experiences.Select(a => a.start_Date).SingleOrDefault(),
                End_Date = b.Experiences.Select(a => a.End_Date).SingleOrDefault(),
                Skill = b.Experiences.Select(a => a.Skill).SingleOrDefault(),
                //
                Exam_Degree_Title = b.Educations.Select(a => a.Exam_Degree_Title).SingleOrDefault(),
                Group_Major_Subject = b.Educations.Select(a => a.Group_Major_Subject).SingleOrDefault(),
                Institute_University = b.Educations.Select(a => a.Institute_University).SingleOrDefault(),
                Result = b.Educations.Select(a => a.Result).SingleOrDefault(),
                CGPA = b.Educations.Select(a => a.CGPA).SingleOrDefault(),
                Scale = b.Educations.Select(a => a.Scale).SingleOrDefault(),
                Year_Of_Passing = b.Educations.Select(a => a.Year_Of_Passing).SingleOrDefault(),
                EduDuration = b.Educations.Select(a => a.Duration).SingleOrDefault(),
                Achievement = b.Educations.Select(a => a.Achievement).SingleOrDefault(),
                //
                Objective = b.Contacts.Select(a => a.Objective).SingleOrDefault(),
                PhoneNumber = b.Contacts.Select(a => a.PhoneNumber).SingleOrDefault(),
                Email = b.Contacts.Select(a => a.Email).SingleOrDefault(),
                LinkdInUrl = b.Contacts.Select(a => a.LinkdInUrl).SingleOrDefault(),
                PermanentAddress = b.Contacts.Select(a => a.PermanentAddress).SingleOrDefault(),
                presentAddress = b.Contacts.Select(a => a.presentAddress).SingleOrDefault(),
                CurrentLocation = b.Contacts.Select(a => a.CurrentLocation).SingleOrDefault(),
                ExpectedSalary = b.Contacts.Select(a => a.ExpectedSalary).SingleOrDefault(),

            }).ToList();


            return new  ViewAsPdf(ab);
        }

    }
}