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
    public class MemberController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        public MemberController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            // get a list of users
            var users = _userManager.Users.ToList();
            // get a list of members
            var members = await _userManager.GetUsersInRoleAsync("Member");


            return View(members);

        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            await _userManager.CreateAsync(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _userManager.FindByIdAsync(id);
                //.FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }
    }
}
