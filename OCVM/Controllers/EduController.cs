using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OCVM.Data;
using OCVM.Data.Interfaces;
using OCVM.Models;
using OCVM.ViewModels;

namespace OCVM.Controllers
{
    public class EduController : Controller
    {

        private readonly IEducationRepository educationRepository;
        private readonly IPersonalDetailsRepository  personalDetails;
        private readonly OcvmContext context;

        public EduController(IEducationRepository _educationRepository, IPersonalDetailsRepository _personalDetails, OcvmContext _context)
        {
            educationRepository = _educationRepository;
            personalDetails = _personalDetails;
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EduInfo(int id)
        {
            IEnumerable<EduViewModel> info = educationRepository.GetAll().Where(a => a.PersonalID == id).Select(b => new EduViewModel
            {
                Exam_Degree_Title = b.Exam_Degree_Title,
                Institute_University = b.Institute_University,
                EduID = b.EduID,
                Year_Of_Passing = b.Year_Of_Passing,
                Group_Major_Subject = b.Group_Major_Subject,
                Result = b.Result,
                CGPA = b.CGPA,
                Achievement = b.Achievement,
                Scale = b.Scale,
                PersonalID = b.PersonalID,
                Duration = b.Duration
            }).ToList();
            
            return View(info);
        }
        public ViewResult Create(int? Pid)
        {
            Education edu = new Education();
            if (Pid != null)
            {
                edu.PersonalID = (int)Pid;
            }

            var EduVm = new EduVm
            {
                personalDetails = personalDetails.GetAll(),
                Education = edu
            };

            var List = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = context.PersonalDetail.Max(m => Convert.ToString(m.PersonalID)),
                    Text = context.PersonalDetail.Max(m => m.FullName),
                    
                    
                }
            };

            ViewData["Pid"] = List;

            return View(EduVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EduVm create)
        {
            if (!ModelState.IsValid)
            {
                create.personalDetails = personalDetails.GetAll();
                return View(create);
            }

            educationRepository.Create(create.Education);

           
            return RedirectToAction("Create", "Exp" );
        }

        public IActionResult Update(int id)
        {
            

            var user = educationRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Education edu)
        {
            if (!ModelState.IsValid)
            {
                return View(edu);
            }
            educationRepository.Update(edu);
            return RedirectToAction("AllCvDetails");
        }
    }
}