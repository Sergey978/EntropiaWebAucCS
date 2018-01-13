using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain;
using EntropiaWebAuc.Areas.Admin.ViewModel;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class StandartItemController : Controller
    {
        private IRepository repo;
        private CategoryViewModel categoryVM;

        // GET: StandartItem
        public StandartItemController(IRepository repo)
        {
            this.repo = repo;
            this.categoryVM = new CategoryViewModel();

        }

        public ViewResult Index()
        {
            var items = repo.StandartItems;
          
            return View(items);
        }

        public ViewResult Create()
        {


            ViewBag.Categories = getStandartItemCategories();

            return View("Edit", new StandartItems());
        }

        public ViewResult Edit(int id)
        {

            StandartItems item = repo.StandartItems
                .FirstOrDefault<StandartItems>(p => p.Id == id);

            ViewBag.Categories = getStandartItemCategories();

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StandartItems item)
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
            StandartItems deleteItem = repo.RemoveStandartItem(id);
            if (deleteItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteItem.Name);
            }
            return RedirectToAction("Index");
        }


        //Helpers

        // Выборка списка   категирий c именами родителей (LEFT JOIN)
        public List<CategoryViewModel> getStandartItemCategories()
        {
            var categories = repo.StandartItemCategories;
           
            var source = (from cat1 in categories
                          join cat2 in categories on
                              cat1.ParentId equals cat2.Id into a
                              from b in a.DefaultIfEmpty()
                          select new CategoryViewModel() { Id = cat1.Id, 
                              Name = cat1.Name, 
                              ParentId = cat1.ParentId,
                              ParentName = b.Name})
                              .Where(c => c.ParentId != null).ToList<CategoryViewModel>();

             
           return source;
                
        }
    }
}