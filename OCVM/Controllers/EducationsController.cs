using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCVM.Data;
using OCVM.Models;

namespace OCVM.Controllers
{
    public class EducationsController : Controller
    {
        private readonly OcvmContext _context;

        public EducationsController(OcvmContext context)
        {
            _context = context;
        }

        // GET: Educations
        public async Task<IActionResult> Index()
        {
            var ocvmContext = _context.Educations.Include(e => e.PersonalDetail);
            return View(await ocvmContext.ToListAsync());
        }

        // GET: Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.PersonalDetail)
                .FirstOrDefaultAsync(m => m.EduID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Educations/Create
        public IActionResult Create()
        {
            
            ViewData["PersonalID"] = new SelectList(_context.PersonalDetail.Max( a => Convert.ToString(a.PersonalID)), "PersonalID", "FullName");
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EduID,Exam_Degree_Title,Group_Major_Subject,Institute_University,Result,CGPA,Scale,Year_Of_Passing,Duration,Achievement,PersonalID,TraningID")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["PersonalID"] = new SelectList(_context.PersonalDetail, "PersonalID", "PersonalID", education.PersonalID);
            return View(education);
        }

        // GET: Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["PersonalID"] = new SelectList(_context.PersonalDetail, "PersonalID", "PersonalID", education.PersonalID);
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EduID,Exam_Degree_Title,Group_Major_Subject,Institute_University,Result,CGPA,Scale,Year_Of_Passing,Duration,Achievement,PersonalID,TraningID")] Education education)
        {
            if (id != education.EduID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.EduID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonalID"] = new SelectList(_context.PersonalDetail, "PersonalID", "PersonalID", education.PersonalID);
            return View(education);
        }

        // GET: Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.PersonalDetail)
                .FirstOrDefaultAsync(m => m.EduID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.EduID == id);
        }
    }
}
