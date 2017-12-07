using System;
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
using EntropiaWebAuc.Domain;
using EntropiaWebAuc.Areas.Admin.ViewModel;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class RoleController : Controller
    {
        private IRepository repo;

        public List<RoleViewModel> roleVM;

        public RoleController(IRepository repo)
        {
            this.repo = repo;

        }

        public ActionResult Index()
        {

            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                List<RoleOption> roleOptions = repo.RoleOptions.ToList<RoleOption>();
                List<IdentityRole> roles = roleManager.Roles.ToList();

                roleVM = (from r in roles
                          join ro in roleOptions on r.Id equals ro.Id into rvm
                          from ro in rvm.DefaultIfEmpty()
                          select new RoleViewModel
                          {
                              Id = r.Id,
                              Name = r.Name,
                              NumberPoint = ro == null ? 0 : ro.AmountPoints,
                              NumberStandartItems = ro == null ? 0 : ro.AmountStandartItems,
                              NumberCustomItems = ro == null ? 0 : ro.AmountCustomItems
                          }).ToList();
            }





            return View(roleVM);
        }


        public ViewResult Edit(string id)
        {
            RoleViewModel editRoleVM;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                IdentityRole role = roleManager.Roles.FirstOrDefault<IdentityRole>(r => r.Id == id);
                RoleOption roleOptions = repo.RoleOptions.FirstOrDefault<RoleOption>(ro => ro.Id == id);

                editRoleVM = new RoleViewModel
                 {
                     Id = role.Id,
                     Name = role.Name,
                     NumberPoint = roleOptions == null ? 0 : roleOptions.AmountPoints,
                     NumberStandartItems = roleOptions == null ? 0 : roleOptions.AmountStandartItems,
                     NumberCustomItems = roleOptions == null ? 0 : roleOptions.AmountCustomItems
                 };

            }

            return View(editRoleVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleViewModel role)
        {

            if (ModelState.IsValid)
            {
                if (role.Id == "")
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var roleStore = new RoleStore<IdentityRole>(context);
                        var roleManager = new RoleManager<IdentityRole>(roleStore);
                        IdentityRole newRole = new IdentityRole(role.Name);
                        roleManager.Create(newRole);
                        context.SaveChanges();

                        repo.CreateRoleOption(new RoleOption
                        {
                            Id = newRole.Id,
                            AmountPoints = role.NumberPoint,
                            AmountStandartItems = role.NumberStandartItems,
                            AmountCustomItems = role.NumberCustomItems
                        });
                    }


                }
                else
                {
                    repo.UpdateRoleOption(new RoleOption
                    {
                        Id = role.Id,
                        AmountPoints = role.NumberPoint,
                        AmountStandartItems = role.NumberStandartItems,
                        AmountCustomItems = role.NumberCustomItems
                    });
                }

                TempData["message"] = string.Format("{0} has been saved", role.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(role);
            }
        }


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

            List<IdentityRole> roles;
            List<ApplicationUser> users;

            List<UsersRoles> usersAndRoles = new List<UsersRoles>();

            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                roles = roleStore.Roles.ToList();
                users = userStore.Users.ToList();



                foreach (ApplicationUser user in users)
                {
                    usersAndRoles.Add(new UsersRoles
                    {
                        User = user,
                        UserRoles = userManager.GetRoles(user.Id).ToList(),
                        selected = false
                    });

                }


            }
            ViewBag.Roles = roles;


            return View(usersAndRoles);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(IList<UsersRoles> usersRoles, FormCollection form)
        {
            List<String> resultMessages = new List<String>();
            using (var context = new ApplicationDbContext())
            {

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var role = roleManager.FindById(Convert.ToString(form["roleId"]));
                if (role == null)
                    throw new Exception("Role not found!");

                String action = Convert.ToString(form["actionId"]);

                switch (action)
                {
                    case "add":
                        {

                            for (int i = 0; i < usersRoles.Count(); i++)
                            {
                                if (usersRoles[i].selected == true)
                                {
                                    var user = userManager.FindByName(usersRoles[i].User.UserName);
                                    if (user == null)
                                        throw new Exception("User not found!");

                                    if (userManager.IsInRole(user.Id, role.Name.ToString()))
                                    {
                                        resultMessages.Add(user.UserName + " already has the role specified !");
                                    }
                                    else
                                    {
                                        if (user.Roles.Count() >= 1)
                                        {
                                            var userRoles = user.Roles;
                                            
                                        }
                                           
                                    //    userManager.RemoveFromRoles(user.Id, usersRoles[i].UserRoles.ToArray());
                                        userManager.AddToRole(user.Id, role.Name);
                                        context.SaveChanges();
                                        resultMessages.Add(user.UserName + " added to the role succesfully !");
                                    }
                                }

                            }

                        }
                        break;
                    case "remove":
                        {
                            for (int i = 0; i < usersRoles.Count(); i++)
                            {
                                if (usersRoles[i].selected == true)
                                {
                                    var user = userManager.FindByName(usersRoles[i].User.UserName);
                                    if (user == null)
                                        throw new Exception("User not found!");

                                    if (userManager.IsInRole(user.Id, role.Name))
                                    {
                                        userManager.RemoveFromRole(user.Id, role.Name);
                                        context.SaveChanges();

                                        resultMessages.Add(user.UserName + "Role removed from this user successfully !");
                                    }
                                    else
                                    {
                                        resultMessages.Add(user.UserName + " doesn't belong to selected role.!");

                                    }
                                }

                            }

                        }
                        break;
                }

            }
            ViewBag.ResultMessages = resultMessages;
            return RedirectToAction("RoleAddToUser");
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