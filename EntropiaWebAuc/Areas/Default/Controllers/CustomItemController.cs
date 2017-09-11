using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain;
using Microsoft.AspNet.Identity;



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
    }
}