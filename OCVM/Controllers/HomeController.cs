using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCVM.Models;
using OCVM.Data.Interfaces;
using OCVM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace OCVM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonalDetailsRepository personalDetails;
        private readonly IEducationRepository educationRepository;
        private readonly IExperienceRepository experienceRepository;
        private readonly ITrainingRepository trainingRepository;
        private readonly IContactRepository contactRepository;


        public HomeController(IPersonalDetailsRepository _repository, IEducationRepository education, IExperienceRepository experience, ITrainingRepository  training, IContactRepository contact )
        {
            personalDetails = _repository;
            educationRepository = education;
            experienceRepository = experience;
            trainingRepository = training;
            contactRepository = contact;
        }
  
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Personal(int id)
        {
            var info = personalDetails.GetById(id);
            return View(info);
        }

        public IActionResult PersonalDetail()
        {
            List<PersonalView> personals = personalDetails.GetPersonalDetails().Select(m => new PersonalView
            {
                FullName = m.FullName,
                UserPicture = m.UserPicture,
                Objective = m.Contacts.Select(a => a.Objective).SingleOrDefault(),
                Skill = m.Experiences.Select(a => a.Skill).SingleOrDefault(),
                Designation = m.Experiences.Select(a => a.Designation).SingleOrDefault(),
                ExpectedSalary = m.Contacts.Select(a => a.ExpectedSalary).SingleOrDefault(),
                CurrentLocation = m.Contacts.Select(a => a.CurrentLocation).SingleOrDefault(),
                Training_Title = m.Trainings.Select(a => a.Training_Title).SingleOrDefault(),
                Exam_Degree_Title = m.Educations.Select(a => a.Exam_Degree_Title).SingleOrDefault(),

            }).ToList();
          
            return View(personals);
        }

       

        public IActionResult Update(int id)
        {
            //List<EditVm> list = personalDetails.ge

            var user = personalDetails.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PersonalDetail detail)
        {
            if (!ModelState.IsValid)
            {
                return View(detail);
            }
            personalDetails.Update(detail);
            return RedirectToAction("Index");
        }
      

        public ViewResult Create()
        {
            return View(new CreateVm { Referer = Request.Headers["Referer"].ToString() });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateVm create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            personalDetails.Create(create.PersonalDetail);

            if (!String.IsNullOrEmpty(create.Referer))
            {
                return Redirect(create.Referer);
            }
         
            return RedirectToAction("Create", "Contact");
        }

      

        public IActionResult Delete(int id)
        {
            var cvowner = personalDetails.GetById(id);
            personalDetails.Delete(cvowner);
            return RedirectToAction("Personal");
        }

        public ActionResult ImgUpload(int id)
        {

            List<PersonalDetail> content = (from p in personalDetails.GetPersonalDetails()
                                          where p.PersonalID == id
                                          orderby p.PersonalID
                                          select p).ToList();
            ViewData["pictures"] = content;
            return View(personalDetails.GetById(id));
        }
        [HttpPost, ActionName("ImgUpload")]
        public ActionResult ImgUpload(IFormFile file, int id)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");
                if (file.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserImages/" + file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    PersonalDetail pd = (from s in personalDetails.GetPersonalDetails() where s.PersonalID == id select s).First();
                    pd.UserPicture = file.FileName;
                    personalDetails.Update(pd);
                  
                }
                ViewBag.Message = "File Uploaded Successfully!!" + ":" + id;
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
