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
    public class AdminController : Controller
    {

        UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> IndexAsync()
        {
            // get a list of users
            var users = _userManager.Users.ToList();
            // get a list of admins
            var members = await _userManager.GetUsersInRoleAsync("Admin");


            return View(members);

        }
    }
}
