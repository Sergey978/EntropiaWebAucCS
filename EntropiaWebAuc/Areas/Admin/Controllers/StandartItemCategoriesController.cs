using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain.Concrete;
using EntropiaWebAuc.Domain.Entities;
using EntropiaWebAuc.Domain.Abstract;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class StandartItemCategoriesController : Controller
    {
        private IStadartItemCategoryRepo repository;

        public StandartItemCategoriesController(IStadartItemCategoryRepo repository)
        {
            this.repository = repository;
        }

        // GET: Admin/StandartItemCategories
        public ViewResult Index()
        {
            return View(repository.StandartItemCategories);
        }

        public ViewResult Create()
        {
            return View("Edit", new StandartItemCategory());
        }

        public ViewResult Edit(int id)
        {
            StandartItemCategory item = repository.StandartItemCategories
                .FirstOrDefault(p => p.Id == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StandartItemCategory category)
        {
            if (ModelState.IsValid)
            {

                repository.SaveStandartItemCategory(category);
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
            StandartItemCategory deleteCategory = repository.DeleteStandartItemCategory(id);
            if (deleteCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deleteCategory.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
