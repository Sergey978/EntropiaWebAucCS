﻿using EntropiaWebAuc.Areas.Default.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using EntropiaWebAuc.Domain;

namespace EntropiaWebAuc.Areas.Default.Controllers
{
    [Authorize]
    public class GraphController : Controller
    {
        public GraphViewModel ViewModel;

        private IRepository repo;

        private string CurrentUserId;

        public GraphController(IRepository repo)
        {
            this.repo = repo;
            this.ViewModel = new GraphViewModel();

        }


        // GET: Default/Draw
        public ActionResult Index(Item selectedItem)
        {
            ViewModel.SelectedItem = selectedItem;
            if (ViewModel.SelectedItem == null)
            {
                RefreshViewModel();
            }
            

            return View(ViewModel);
        }

        public PartialViewResult _GetItem()
        {
            RefreshViewModel();
            return PartialView("_GetItem", ViewModel);
        }


        public void RefreshViewModel()
        {
            CurrentUserId = User.Identity.GetUserId();

            // получаем список выбранных кастомных элементов
            IEnumerable<Item> selectedCustom = repo.CustomItems
             .Where<CustomItem>(c => c.UserId == CurrentUserId && (c.Chosed == true))
             .Select(item => new Item()
             {
                 Id = "custom-" + item.Id.ToString(),
                 Name = item.Name,
                 Price = item.Price,
                 BeginQuantity = item.BeginQuantity,
                 Step = item.Step,
                 Markup = item.Markup,
                 PurchasePrice = item.PurchasePrice
             });
            // select standart items that user has choise
            IEnumerable<Item> selectedStandart =
                repo.StandartItems.Join(repo.SelectedStandartItems
                .Where(u =>u.UserId == CurrentUserId),
                a => a.Id, b => b.ItemId , 
                (a, b) => new Item()
                {
                    Id = "standart-" + a.Id.ToString(),
                    Name = a.Name,
                    Price = a.Price,
                    BeginQuantity = b.BeginQuantity,
                    Step = b.Step,
                    Markup = b.Markup,
                    PurchasePrice = b.PurchasePrice
                });

              ViewModel.Items = selectedCustom.Concat<Item>(selectedStandart);
            // Если не выбраны елементы создадим пустой елемент для отображения в списке
            if (!ViewModel.Items.Any<Item>())
            {
                ViewModel.Items = new Item[] { new Item() { Id = "noelement", Name = "No Element", Price = 0 } };
            }
            if(ViewModel.SelectedItem == null)
            {
                ViewModel.SelectedItem = ViewModel.Items.FirstOrDefault<Item>();
            }
            
        }

        [HttpPost]
        public ActionResult _GetItemJSON(string val)
        {

            RefreshViewModel();
            IItem selectedItem = null;
            if (val != null)
            {
                selectedItem = ViewModel.Items.FirstOrDefault<IItem>(i => i.Id.Equals(val));
            }
            return Json(new { Succes = "true", Data = selectedItem });
        }

    [HttpPost]
        public ActionResult Calc(Item selectedItem)
        {
                    
            if (ModelState.IsValid)
            {
               
                ViewModel.SelectedItem = new Item()
                {
                    /*
                    Id = form["Items"].ToString(),
                    Name = "",
                    Price = 0,
                    BeginQuantity = Int32.Parse(form["quantity"]),
                    Step = Int32.Parse(form["step"]),
                    Markup = Decimal.Parse(form["markup"]),
                    PurchasePrice = Decimal.Parse(form["purchasePrice"])
                     */
                };

                return RedirectToAction("Index");
            }
            return View("Index", selectedItem);

        }



    }
}