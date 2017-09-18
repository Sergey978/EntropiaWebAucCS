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
            List<StandartItemCategory> categories =
                repo.StandartItemCategories.ToList<StandartItemCategory>();

            categories.Insert(0, null);

            ViewBag.Categories = categories;

            return View("Edit", new StandartItemCategory());
        }

        public ViewResult Edit(int id)
        {
            StandartItemCategory item = repo.StandartItemCategories
                .FirstOrDefault(p => p.Id == id);

            List<StandartItemCategory> categories =
                 repo.StandartItemCategories.ToList<StandartItemCategory>();

            categories.Remove(item);
            categories.Insert(0,null);

            ViewBag.Categories = categories;
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StandartItemCategory category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id != 0)
                {
                    repo.UpdateStandartItemCategory(category);
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
            StandartItemCategory deleteCategory = repo.RemoveStandartItemCategory(id);
            if (deleteCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteCategory.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
