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
    public class ContactController : Controller
    {
        private readonly IPersonalDetailsRepository personalDetails;
        private readonly IContactRepository contactRepository;
        private readonly OcvmContext context;
        public ContactController(IPersonalDetailsRepository _personalDetails, IContactRepository _contactRepository, OcvmContext _context)
        {
            personalDetails = _personalDetails;
            contactRepository = _contactRepository;
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Create(int? Pid)
        {
            Contact contact = new Contact();
            if (Pid != null)
            {
                contact.PersonalID = (int)Pid;
            }

            var cont = new ContactVm
            {
                personalDetails = personalDetails.GetAll(),
                Contact = contact
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

            return View(cont);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactVm create)
        {
            if (!ModelState.IsValid)
            {
                create.personalDetails = personalDetails.GetAll();
                return View(create);
            }
            contactRepository.Create(create.Contact);

            return RedirectToAction("Create", "Edu");
        }

        public IActionResult ContactInfo(int id)
        {
            var contact = contactRepository.GetById(id);
            if(contact == null)
            {
                return View("Empty");
            }
            return View(contact);
        }
        public IActionResult Update(int id)
        {
            var user = contactRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            contactRepository.Update(contact);
  
            return RedirectToAction("ContactInfo");
        }

        public IActionResult Delete(int id)
        {
            var ct = contactRepository.GetById(id);
            contactRepository.Delete(ct);
          
            return RedirectToAction("ContactInfo");
        }
    }
}