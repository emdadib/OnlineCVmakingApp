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
    public class TrainingController : Controller
    {
        private readonly IPersonalDetailsRepository detailsRepository;
        private readonly ITrainingRepository trainingRepository;
        private readonly OcvmContext context;

        public TrainingController(IPersonalDetailsRepository _detailsRepository, ITrainingRepository _trainingRepository, OcvmContext _context)
        {
            detailsRepository = _detailsRepository;
            trainingRepository = _trainingRepository;
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Create(int? Pid)
        {
            Training training = new Training();
            if (Pid != null)
            {
                training.PersonalID = (int)Pid;
            }

            var trainingVm = new TrainingVm
            {
                personalDetails = detailsRepository.GetAll(),
                Training = training
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

            return View(trainingVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TrainingVm create)
        {
            if (!ModelState.IsValid)
            {
                create.personalDetails = detailsRepository.GetAll();
                return View(create);
            }

            trainingRepository.Create(create.Training);


            return RedirectToAction("ImgUpload", "Home");
        }

        public IActionResult TrnInfo(int id)
        {
            IEnumerable<TrainingViewModels> info = trainingRepository.GetAll().Where(a => a.PersonalID == id).Select(b => new TrainingViewModels
            {
                TrainingID = b.TrainingID,
                Training_Title = b.Training_Title,
                Country = b.Country,
                Topics_Covered = b.Topics_Covered,
                Training_Year = b.Training_Year,
                Institute = b.Institute,
                Duration = b.Duration,
                Location = b.Location,

                PersonalID = b.PersonalID,

            }).ToList();

            return View(info);
        }
        public IActionResult Update(int id)
        {
            var user = trainingRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Training trn)
        {
            if (!ModelState.IsValid)
            {
                return View(trn);
            }
            trainingRepository.Update(trn);
            //Have To Change the Redirect View
            return RedirectToAction("TrnInfo");
        }
        public IActionResult Delete(int id)
        {
            var tr = trainingRepository.GetById(id);
            trainingRepository.Delete(tr);
            //Have to Change the redirect method
            return RedirectToAction("TrnInfo");
        }
    }
}