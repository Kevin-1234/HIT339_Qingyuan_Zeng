using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InhouseMembership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InhouseMembership.Controllers
{
    public class CoachController : Controller

    {
        UserManager<ApplicationUser> _userManager;
        public CoachController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<ActionResult> Index() 
        {
            // get a list of users
            var users = _userManager.Users.ToList();
            // get a list of Admins
            var coaches = await _userManager.GetUsersInRoleAsync("Coach");
           
                
            return View(coaches);
            
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _userManager.FindByIdAsync(id);
            //.FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

    }
}
