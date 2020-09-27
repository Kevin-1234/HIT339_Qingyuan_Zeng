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
    public class UserController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }



        public async Task<ActionResult> GetAdmins()
        {
            // get a list of admins
            var admins = await _userManager.GetUsersInRoleAsync("Admin");

            // pass the admins to Index view page
            return View("Index", admins);
        }

        public async Task<ActionResult> GetCoaches()
        {
            // get a list of coaches
            var coaches = await _userManager.GetUsersInRoleAsync("Coach");

            // pass the coaches to Index view page
            return View("Index", coaches);
            
        }



        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetMembers()
        {
            // get a list of members
            var members = await _userManager.GetUsersInRoleAsync("Member");

            // pass the members to Index view page
            return View("Index", members);

        }

        public IActionResult Create()
        {
            return Redirect("../Identity/Account/Register");
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

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var User = await _userManager.FindByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Email, PhoneNumber")] ApplicationUser applicationUser)
        {
            
            if (ModelState.IsValid)
            {
                await _userManager.SetUserNameAsync(_userManager.FindByIdAsync(id).Result, applicationUser.UserName);
                await _userManager.SetEmailAsync(_userManager.FindByIdAsync(id).Result, applicationUser.Email);
                await _userManager.SetPhoneNumberAsync(_userManager.FindByIdAsync(id).Result, applicationUser.PhoneNumber);

                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser user = new ApplicationUser();
            user = _userManager.FindByIdAsync(id).Result;

            // check the role of the user that is being deleted, then retrun differnet list accordingly
            foreach (var role in _userManager.GetRolesAsync(user).Result)
            {
                if (role == "Admin")
                {
                    await _userManager.DeleteAsync(user);
                    return View(nameof(Index), await _userManager.GetUsersInRoleAsync("Admin"));
                }
                else if (role == "Coach")
                {
                    await _userManager.DeleteAsync(user);
                    return View(nameof(Index), await _userManager.GetUsersInRoleAsync("Coach"));

                }
                else if (role == "Member")
                {
                    await _userManager.DeleteAsync(user);
                    return View(nameof(Index), await _userManager.GetUsersInRoleAsync("Member"));
                }
    
            }

            return RedirectToAction(nameof(Schedule));

        }
    }
}
