using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InhouseMembership.Data;
using InhouseMembership.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace InhouseMembership.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<IdentityUser> _userManager;

        
        public ScheduleController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public void OnGet()
        {

            ViewData["coaches"] = _userManager.GetUsersInRoleAsync("Coach"); 

            
        }
        // GET: Schedule
        public async Task<IActionResult> Index()
        {
           

            var scheduleList = await _context.Schedules.ToListAsync();
            // ensure the coach logged in can only see the schedule that is hosted by himself
            if (User.IsInRole("Coach"))
            {
                return View(scheduleList.Where(s => s.CoachId.Equals(_userManager.GetUserId(HttpContext.User))));
            }
            // members and admins can see all schedules
            else {
                return View(scheduleList);
            }
            
           
            
        }

        // GET: Schedule/Details/5
        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // redirect to the coach detail page
        public IActionResult CoachDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            return Redirect("../../Coach/Details/" + id);
        }



        
        public IActionResult CreateEnrollment(string id)
        {


            //enrollment.EnrollmentId = "53534534";
            //enrollment.MemberId = _userManager.GetUserAsync(User).Result.Id;
            //enrollment.ScheduleId = "321312";
            //_context.Add(enrollment);
            //await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));

            //var data = new Enrollment()
            //{
            //    EnrollmentId = "111111",
            //    ScheduleId = id,
            //    MemberId = _userManager.GetUserAsync(User).Result.Id

            //};




            // generate random enrollment Id
            Random rnd = new Random();
            int randomNumber = rnd.Next();
            string strRandomNumber = randomNumber.ToString();
            // the data will be passed to the create action in 'Enrollment' controller using TempData to create a new enrollment
            var data = new Dictionary<string, string>() {         
            {"EnrollmentId", strRandomNumber},
            {"ScheduleId", id},
            {"MemberId", _userManager.GetUserAsync(User).Result.Id},
            };
            TempData["mydata"] = data;
            //TempData["mydata"] = JsonConvert.SerializeObject(data);
            return RedirectToAction("Create", "Enrollment");


        }



      




        // GET: Schedule/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            // pass a list of coaches to ViewData, which can be used to Create page for choach and schedule matching
            ViewData["coaches"] = _userManager.GetUsersInRoleAsync("Coach").Result.ToList();
            return View();
        }

        // POST: Schedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ScheduleId,CoachId,EventName,EventDate,Location")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {

                // generate random Schedule Id
                Random rnd = new Random();
                int randomNumber = rnd.Next();
                string strRandomNumber = randomNumber.ToString();
                schedule.ScheduleId = strRandomNumber;
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedule/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("ScheduleId,CoachId,EventName,EventDate,Location")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
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
            return View(schedule);
        }

        // GET: Schedule/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(string id)
        {
            return _context.Schedules.Any(e => e.ScheduleId == id);
        }
    }
}
