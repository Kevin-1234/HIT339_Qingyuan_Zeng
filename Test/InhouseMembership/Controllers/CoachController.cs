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
        //UserManager<IdentityUser> _userManager;
        //public CoachController(UserManager<IdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        [Authorize(Roles = "Coach")]
        //public async Task<ActionResult> Index(
        public ActionResult Index()
        {
           
            //var users = _userManager.Users.ToList();
          
            //var coaches = await _userManager.GetUsersInRoleAsync("Coach");
           
                
            //return View(coaches);
            return View();
        }



    }
}
