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
            CustomItems newItem = new CustomItems();

            CurrentUserId = User.Identity.GetUserId();
            newItem.UserId = CurrentUserId;
            RoleOptions roleOption = RoleModels.GetUserRoleOption(User.Identity.GetUserId(), repo); 

            int currentCountItems = (from custom in repo.CustomItems
                                     where custom.AspNetUsers.Id == CurrentUserId                                    
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

            CustomItems item = repo.CustomItems
                .FirstOrDefault(p => p.Id == id);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(CustomItems item)
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
            CustomItems deleteItem = repo.RemoveCustomItem(id);
            if (deleteItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteItem.Name);
            }
            return RedirectToAction("Index");
        }

      
    }
}