using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;
using EntropiaWebAuc.Domain.Concrete;
using Microsoft.AspNet.Identity;



namespace EntropiaWebAuc.Areas.Default.Controllers
{
    [Authorize]
    public class CustomItemController : Controller
    {
        private ICustomItemRepository itemRepo;
       
        // GET: CustomItem
        public CustomItemController(ICustomItemRepository repository)
        {

            this.itemRepo = repository;
           
        }

        public ViewResult Index()
        {
            var items = itemRepo.CustomItems;
            return View(items);
        }

        public ViewResult Create()
        {
            CustomItem newItem = new CustomItem();
            newItem.UserId = User.Identity.GetUserId();
           
            return View("Edit", newItem);
        }

        public ViewResult Edit(int id)
        {

            CustomItem item = itemRepo.CustomItems
                .FirstOrDefault(p => p.Id == id);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(CustomItem item)
        {


            if (ModelState.IsValid)
            {

                itemRepo.SaveCustomItem(item);
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
            CustomItem deleteItem = itemRepo.DeleteCustomItem(id);
            if (deleteItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteItem.Name);
            }
            return RedirectToAction("Index");
        }
    }
}