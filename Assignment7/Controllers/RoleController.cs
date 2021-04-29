using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assignment7.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMgr)
        {
            roleManager = roleMgr;
            userManager = userMgr;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin()
        {
            bool x;

            x = await roleManager.RoleExistsAsync("Admin");

            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);

                var user = new Models.ApplicationUser();
                user.UserName = "AdminUser";
                user.Email = "AdminUser@gmail.com";

                string userPWD = "Admin@1234";

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Admin");

                    ViewData["Message"] = "Success Role Created";
                }

            }
            else
            {
                ViewData["Message"] = "Sorry, that role already Exists!";
            }
            return View("RoleStatus");
        }

        public async Task<IActionResult> AddUser()
        {
            bool x;

            x = await roleManager.RoleExistsAsync("User");

            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "User";
                await roleManager.CreateAsync(role);

                var user = new Models.ApplicationUser();
                user.UserName = "AuthenticatedUser";
                user.Email = "AuthenticatedUser@gmail.com";

                string userPWD = "User@1234";

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "User");

                    ViewData["Message"] = "Success Role Created";
                }

            }
            else
            {
                ViewData["Message"] = "Sorry, that role already Exists!";
            }
            return View("RoleStatus");
        }

        public async Task<IActionResult> AddOwner()
        {
            bool x;

            x = await roleManager.RoleExistsAsync("Owner");

            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Owner";
                await roleManager.CreateAsync(role);

                var user = new Models.ApplicationUser();
                user.UserName = "OwnerUser";
                user.Email = "OwnerUser@gmail.com";

                string userPWD = "Owner@1234";

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Owner");

                    ViewData["Message"] = "Success Role Created";
                }

            }
            else
            {
                ViewData["Message"] = "Sorry, that role already Exists!";
            }
            return View("RoleStatus");
        }

        public async Task<IActionResult> AddEmployee()
        {
            bool x;

            x = await roleManager.RoleExistsAsync("Admin");

            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                await roleManager.CreateAsync(role);

                var user = new Models.ApplicationUser();
                user.UserName = "EmployeeUser";
                user.Email = "EmployeeUser@gmail.com";

                string userPWD = "Employee@1234";

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Employee");

                    ViewData["Message"] = "Success Role Created";
                }

            }
            else
            {
                ViewData["Message"] = "Sorry, that role already Exists!";
            }
            return View("RoleStatus");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}