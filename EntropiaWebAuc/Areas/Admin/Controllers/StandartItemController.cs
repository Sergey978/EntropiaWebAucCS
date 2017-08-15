using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;
using EntropiaWebAuc.Domain.Concrete;


namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class StandartItemController : Controller
    {
        private IStandartItemRepository itemRepo;
        private IStadartItemCategoryRepo categoryRepo;
        // GET: StandartItem
        public StandartItemController(IStandartItemRepository repository, IStadartItemCategoryRepo categoryRepo)
        {

            this.itemRepo = repository;
            this.categoryRepo = categoryRepo;
        }

        public ViewResult Index()
        {
            var items = itemRepo.StandartItems;
            return View(items);
        }

        public ViewResult Create()
        {
            // Выборка списка   категирий без дочерних 
            List<StandartItemCategory> categories =
                 categoryRepo.StandartItemCategories
                 .Where(c => c.Children.Count == 0)
                 .ToList<StandartItemCategory>();

            ViewBag.Categories = categories;

            return View("Edit", new StandartItem());
        }

        public ViewResult Edit(int id)
        {

            StandartItem item = itemRepo.StandartItems
                .FirstOrDefault(p => p.Id == id);

            // Выборка списка   категирий без дочерних  
            List<StandartItemCategory> categories =
                 categoryRepo.StandartItemCategories
                 .Where(c => c.Children.Count == 0)
                 .ToList<StandartItemCategory>();

            ViewBag.Categories = categories;

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StandartItem item)
        {


            if (ModelState.IsValid)
            {

                itemRepo.SaveStandartItem(item);
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
            StandartItem deleteItem = itemRepo.DeleteStandartItem(id);
            if (deleteItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteItem.Name);
            }
            return RedirectToAction("Index");
        }
    }
}