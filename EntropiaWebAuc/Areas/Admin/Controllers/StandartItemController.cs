using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Abstract;
using EntropiaWebAuc.Entities;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    public class StandartItemController : Controller
    { 
        private IStandartItemRepository repository;
        // GET: StandartItem
        public StandartItemController( IStandartItemRepository repository)
        {

            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.StandartItems);
        }

        public ViewResult Create()
        {
            return View("Edit", new StandartItem());
        }

        public ViewResult Edit(int id)
        {
            StandartItem item = repository.StandartItems
                .FirstOrDefault(p => p.ItemId == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StandartItem item)
        {
            if (ModelState.IsValid)
            {
                
                repository.SaveStandartItem(item);
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
        public ActionResult Delete(int itemId)
        {
            StandartItem deleteItem = repository.DeleteStandartItem(itemId);
            if (deleteItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteItem.Name);
            }
            return RedirectToAction("Index");
        }
    }
}