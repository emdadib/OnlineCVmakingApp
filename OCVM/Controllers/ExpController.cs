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
    public class ExpController : Controller
    {
        private readonly IExperienceRepository experienceRepository;
        private readonly IPersonalDetailsRepository personalDetails;
        private readonly OcvmContext context;

        public ExpController(IExperienceRepository _experienceRepository, IPersonalDetailsRepository _personalDetails, OcvmContext _context)
        {
            experienceRepository = _experienceRepository;
            personalDetails = _personalDetails;
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Create(int? Pid)
        {
             Experience exp = new Experience();
            if (Pid != null)
            {
                exp.PersonalID = (int)Pid;
            }

            var ExpVm = new ExperianceVm
            {
                personalDetails = personalDetails.GetAll(),
                Experience = exp
            };
            var List = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = context.PersonalDetail.Max(m => Convert.ToString(m.PersonalID)),
                    Text = context.PersonalDetail.Max(m => m.FullName)
                 
                }
            };

            ViewData["Pid"] = List;

            return View(ExpVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExperianceVm create)
        {
            if (!ModelState.IsValid)
            {
                create.personalDetails = personalDetails.GetAll();
                return View(create);
            }
            experienceRepository.Create(create.Experience);

            return RedirectToAction("Create", "Training");
        }
        public IActionResult ExpInfo(int id)
        {
            IEnumerable<ExpViewModels> info = experienceRepository.GetAll().Where(a => a.PersonalID == id).Select(b => new ExpViewModels
            {
                ExperienceID = b.ExperienceID,
                Company_Name = b.Company_Business,
                Company_Business = b.Company_Business,
                Designation = b.Designation,
                Department = b.Department,
                start_Date = b.start_Date,
                End_Date = b.End_Date,
                Skill = b.Skill,
              
                PersonalID = b.PersonalID,
              
            }).ToList();

            return View(info);
        }
        public IActionResult Update(int id)
        {
           var user = experienceRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Experience exp)
        {
            if (!ModelState.IsValid)
            {
                return View(exp);
            }
            experienceRepository.Update(exp);
            //Have To Change the Redirect View
            return RedirectToAction("AllCvDetails");
        }


        public IActionResult Delete(int id)
        {
            var ex = experienceRepository.GetById(id);
            experienceRepository.Delete(ex);
            //Have to Change the redirect method
            return RedirectToAction("ExpInfo");
        }



    }
}