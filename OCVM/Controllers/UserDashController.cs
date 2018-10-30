using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OCVM.Data;

namespace OCVM.Controllers
{
    public class UserDashController : Controller
    {
        private readonly OcvmContext _context;
        private readonly ApplicationDbContext userContext;

        public UserDashController(OcvmContext context, ApplicationDbContext userContext)
        {
            _context = context;
            this.userContext = userContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
            
        }
        public IActionResult Show()
        {
            var contctEmail = _context.Contacts.Select(x => x.Email);
            var userEmail = userContext.Users.Select(x => x.Email);
            if (contctEmail == userEmail)
            {
                ViewBag.Email = contctEmail;
                return View();
            }
            else
            {
                return View("Empty");
            }

        }
    }
}