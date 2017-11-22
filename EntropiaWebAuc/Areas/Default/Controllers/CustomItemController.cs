using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain;
using Microsoft.AspNet.Identity;
using EntropiaWebAuc.Areas.Default.Models;
using Microsoft.AspNet.Identity.EntityFramework;



namespace EntropiaWebAuc.Areas.Default.Controllers
{
    [Authorize]
    public class CustomItemController : Controller
    {
        private IRepository repo;

        private string CurrentUserId;

        // GET: CustomItem
        public CustomItemController(IRepository repository)
        {

            this.repo = repository;

        }

        public ViewResult Index()
        {
            CurrentUserId = User.Identity.GetUserId();

            var items = repo.CustomItems.
                Where(c => c.UserId == CurrentUserId);
            return View(items);
        }

        public ViewResult Create()
        {
            CustomItem newItem = new CustomItem();

            CurrentUserId = User.Identity.GetUserId();
            newItem.UserId = CurrentUserId;
            RoleOption roleOption = GetUserRoleOption();

            int currentCountItems = (from custom in repo.CustomItems
                                     where custom.AspNetUser.Id == CurrentUserId                                    
                                     select custom).Count();
            // check how many custom items the user has
           if (currentCountItems >= roleOption.AmountCustomItems  )
           {
               ViewBag.errorMessage = "reached a limit of custom items";
           }

            return View("Edit", newItem);
        }

        public ViewResult Edit(int id)
        {

            CustomItem item = repo.CustomItems
                .FirstOrDefault(p => p.Id == id);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(CustomItem item)
        {

            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                {
                    repo.CreateCustomItem(item);

                }
                else
                {
                    repo.UpdateCustomItem(item);
                }

                TempData["message"] = string.Format("{0} has been saved", item.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(item);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CustomItem deleteItem = repo.RemoveCustomItem(id);
            if (deleteItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteItem.Name);
            }
            return RedirectToAction("Index");
        }

        private RoleOption GetUserRoleOption()
        {
            CurrentUserId = User.Identity.GetUserId();
            RoleOption roleOption;

            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = userManager.FindById(CurrentUserId);
                var userRoleId = (from r in user.Roles select r.RoleId).First();

                roleOption = (from ro in repo.RoleOptions
                              where ro.Id == userRoleId
                              select ro).First();


            }
            return roleOption;
        }
    }
}