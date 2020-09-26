using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InhouseMembership.Data;
using InhouseMembership.Models;
using Newtonsoft.Json;

namespace InhouseMembership.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            //var tupleModel = new Tuple<IEnumerable<Schedule>, IEnumerable<Enrollment>>(await _context.Schedules.ToListAsync(), await _context.Enrollments.ToListAsync());
            //return View(tupleModel);
            return View(await _context.Enrollments.ToListAsync());
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollment/Create
        public async Task<IActionResult> Create([Bind("EnrollmentId,ScheduleId,MemberId")] Enrollment enrollment)
        {
            Console.WriteLine("haha");
            //TempData["mydata"] = JsonConvert.DeserializeObject<Enrollment>(TempData["mydata"]);
            var data = TempData["mydata"] as Dictionary<string, string>;
            //ViewData["mydata"] = JsonConvert.DeserializeObject(TempData["mydata"]);
            
            enrollment.EnrollmentId = data["EnrollmentId"];
            enrollment.ScheduleId = data["ScheduleId"];
            enrollment.MemberId = data["MemberId"];
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Schedule");
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //public async Task<IActionResult> Create([Bind("EnrollmentId,ScheduleId,MemberId")] Enrollment enrollment)
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("EnrollmentId,ScheduleId,MemberId")] Enrollment enrollment)
        //{
            //if (ModelState.IsValid)
            //{
            //Enrollment data = TempData["mydata"] as Enrollment;
            //TempData["mydata"] = JsonConvert.DeserializeObject<Enrollment>((string)TempData["mydata"]);
            //var data = TempData["mydata"];
            //Console.WriteLine("data: " + data);

            //enrollment.EnrollmentId = "12312354645";
            //enrollment.ScheduleId = "12312";
            //enrollment.MemberId = "1231443";

            
            //    _context.Add(enrollment);
            //    await _context.SaveChangesAsync();
                
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(enrollment);
        //}

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EnrollmentId,ScheduleId,MemberId")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentId))
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
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(string id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentId == id);
        }
    }
}
