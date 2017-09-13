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

        // Выборка списка   категирий c именами родителей (LEFT JOIN)
        public List<CategoryViewModel> getStandartItemCategories()
        {

            return repo.StandartItemCategories.Join(repo.StandartItemCategories,
                l => l.ParentId, r =>r.Id,
                (x, y) => new CategoryViewModel()).
                SelectMany(x => x.DefaultIfEmpty(), (x, y) => )
                

                );

            /* example on stack
             * 
             * https://stackoverflow.com/questions/12075905/left-outer-join-in-lambda-method-syntax-in-linq
             * 
             * Parent
                    {
                        PID     // PK
                    }

                    Child
                    {
                        CID     // PK
                        PID     // FK
                        Text
                    }
             * 
                             * var source = lParent.GroupJoin(
                                    lChild,
                                    p => p.PID,
                                    c => c.PID,
                                    (p, g) => g
                                        .Select(c => new { PID = p.PID, CID = c.CID, Text = c.Text })
                                        .DefaultIfEmpty(new { PID = p.PID, CID = -1, Text = "[[Empty]]" }))
                                    .SelectMany(g => g);
                             * 
             * 
             */
                
        }
    }
}