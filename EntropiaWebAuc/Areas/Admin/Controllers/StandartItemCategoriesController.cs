using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain;


namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class StandartItemCategoriesController : Controller
    {
        private IRepository repo;

        public StandartItemCategoriesController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: Admin/StandartItemCategories
        public ViewResult Index()
        {
            return View(repo.StandartItemCategories);
        }

        public ViewResult Create()
        {
            List<StandartItemCategories> categories =
                repo.StandartItemCategories.ToList<StandartItemCategories>();

            categories.Insert(0, null);

            ViewBag.Categories = categories;

            return View("Edit", new StandartItemCategories());
        }

        public ViewResult Edit(int id)
        {
            StandartItemCategories item = repo.StandartItemCategories.
                FirstOrDefault<StandartItemCategories>(p => p.Id == id);
             

            List<StandartItemCategories> categories =
                 repo.StandartItemCategories.ToList<StandartItemCategories>();

            categories.Remove(item);
            categories.Insert(0,null);

            ViewBag.Categories = categories;
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StandartItemCategories category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id != 0)
                {
                    repo.UpdateStandartItemCategories(category);
                }
                else
                    repo.CreateStandartItemCategory(category);

              
                TempData["message"] = string.Format("{0} has been saved", category.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(category);
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            StandartItemCategories deleteCategory = repo.RemoveStandartItemCategory(id);
            if (deleteCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteCategory.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
