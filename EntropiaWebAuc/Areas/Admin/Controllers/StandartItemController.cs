using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class StandartItemController : Controller
    {
        private IRepository repo;

        // GET: StandartItem
        public StandartItemController(IRepository repo)
        {
            this.repo = repo;

        }

        public ViewResult Index()
        {
            var items = repo.StandartItems;
            return View(items);
        }

        public ViewResult Create()
        {


            ViewBag.Categories = getStandartItemCategories();

            return View("Edit", new StandartItem());
        }

        public ViewResult Edit(int id)
        {

            StandartItem item = repo.StandartItems
                .FirstOrDefault(p => p.Id == id);

            ViewBag.Categories = getStandartItemCategories();

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StandartItem item)
        {

            if (ModelState.IsValid)
            {
                repo.UpdateStandartItem(item);
                TempData["message"] = string.Format("{0} has been saved", item.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                ViewBag.Categories = getStandartItemCategories();
                return View(item);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            StandartItem deleteItem = repo.RemoveStandartItem(id);
            if (deleteItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteItem.Name);
            }
            return RedirectToAction("Index");
        }


        //Helpers

        // Выборка списка   категирий без дочерних 
        public List<StandartItemCategory> getStandartItemCategories()
        {

            return repo.StandartItemCategories.ToList();
                
        }
    }
}