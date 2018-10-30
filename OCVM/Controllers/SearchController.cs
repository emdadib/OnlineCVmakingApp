using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCVM.Data.Repository;
using OCVM.Data.Interfaces;
using OCVM.ViewModels;
using OCVM.Models;
using OCVM.Data;
using PagedList.Core;

namespace OCVM.Controllers
{
    //[Route("Search")]
    public class SearchController : Controller
    {
        private readonly OcvmContext context;
       

        public SearchController(OcvmContext context, IExperienceRepository experience)
        {
            this.context = context;
        }

        //[Route("Index")]
        //[Route(" ")]
        //[Route("~/")]

        //public IActionResult Index()
        //{
        //   return View();
        //}
        //[HttpGet]
        //[Route("search")]
        //public IActionResult Search(int page = 1, int pageSize = 6)
        //{
        //    var keyword = Request.Query["keyword"].ToString();
        //    PagedList<Experience> model = new PagedList<Experience>
        //        (
        //            context.Experiences, page, pageSize
        //        );
        //    ViewBag.keyword = keyword;
        //   return View("Index", model);
        //}
      
    }
}