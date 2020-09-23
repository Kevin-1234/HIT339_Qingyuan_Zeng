using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InhouseMembership.Controllers
{
    public class CoachController : Controller

    {
        UserManager<IdentityUser> _userManager;
        public CoachController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index() 
        {
            // get a list of users
            var users = _userManager.Users.ToList();
            // get a list of Admins
            var coaches = await _userManager.GetUsersInRoleAsync("Coach");
           
                
            return View(coaches);
            
        }



    }
}
