﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using EntropiaWebAuc.Areas.Default.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class RoleController : Controller
    {

        public ActionResult RoleCreate()
        {
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(string roleName)
        {
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roleManager.Create(new IdentityRole(roleName));
                context.SaveChanges();
            }

            ViewBag.ResultMessage = "Role created successfully !";
            return RedirectToAction("Index", "Role");
        }


        public ActionResult Index()
        {
            List<string> roles;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roles = (from r in roleManager.Roles select r.Name).ToList();
            }

            return View(roles.ToList());
        }


        public ActionResult RoleDelete(string roleName)
        {
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = roleManager.FindByName(roleName);

                roleManager.Delete(role);
                context.SaveChanges();
            }

            ViewBag.ResultMessage = "Role deleted succesfully !";
            return RedirectToAction("Index", "Role");
        }


        public ActionResult RoleAddToUser()
        {
            List<string> roles;
            List<string> users;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();
                roles = (from r in roleManager.Roles select r.Name).ToList();
            }

            ViewBag.Roles = new SelectList(roles);
            ViewBag.Users = new SelectList(users);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string roleName, string userName)
        {
            List<string> roles;
            List<string> users;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();

                var user = userManager.FindByName(userName);
                if (user == null)
                    throw new Exception("User not found!");

                var role = roleManager.FindByName(roleName);
                if (role == null)
                    throw new Exception("Role not found!");

                if (userManager.IsInRole(user.Id, role.Name))
                {
                    ViewBag.ResultMessage = "This user already has the role specified !";
                }
                else
                {
                    userManager.AddToRole(user.Id, role.Name);
                    context.SaveChanges();

                    ViewBag.ResultMessage = "Username added to the role succesfully !";
                }

                roles = (from r in roleManager.Roles select r.Name).ToList();
            }

            ViewBag.Roles = new SelectList(roles);
            ViewBag.Users = new SelectList(users);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                List<string> userRoles;
                List<string> roles;
                List<string> users;
                using (var context = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    roles = (from r in roleManager.Roles select r.Name).ToList();

                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    users = (from u in userManager.Users select u.UserName).ToList();

                    var user = userManager.FindByName(userName);
                    if (user == null)
                        throw new Exception("User not found!");

                    var userRoleIds = (from r in user.Roles select r.RoleId);
                    userRoles = (from id in userRoleIds
                                 let r = roleManager.FindById(id)
                                 select r.Name).ToList();
                }

                ViewBag.Roles = new SelectList(roles);
                ViewBag.Users = new SelectList(users);
                ViewBag.RolesForThisUser = userRoles;
            }

            return View("RoleAddToUser");
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string userName, string roleName)
        {
            List<string> userRoles;
            List<string> roles;
            List<string> users;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roles = (from r in roleManager.Roles select r.Name).ToList();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();

                var user = userManager.FindByName(userName);
                if (user == null)
                    throw new Exception("User not found!");

                if (userManager.IsInRole(user.Id, roleName))
                {
                    userManager.RemoveFromRole(user.Id, roleName);
                    context.SaveChanges();

                    ViewBag.ResultMessage = "Role removed from this user successfully !";
                }
                else
                {
                    ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                }

                var userRoleIds = (from r in user.Roles select r.RoleId);
                userRoles = (from id in userRoleIds
                             let r = roleManager.FindById(id)
                             select r.Name).ToList();
            }

            ViewBag.RolesForThisUser = userRoles;
            ViewBag.Roles = new SelectList(roles);
            ViewBag.Users = new SelectList(users);
            return View("RoleAddToUser");
        }


    }
}