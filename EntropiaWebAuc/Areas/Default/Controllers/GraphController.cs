using EntropiaWebAuc.Areas.Default.ViewModels;
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

        public GraphController(IRepository repo)
        {
            this.repo = repo;
            this.ViewModel = new GraphViewModel();

        }


        // GET: Default/Draw
        public ActionResult Index()
        {
           
            return View();
        }

        public PartialViewResult _GetItem(Item selectedItem)
        {
            ViewModel.Items = GetListUserItems();

            if (selectedItem.Id == null)
            {
                ViewModel.SelectedItem = ViewModel.Items.FirstOrDefault<Item>();
            }
            else ViewModel.SelectedItem = selectedItem;
            
            return PartialView("_GetItem", ViewModel);
        }

        [HttpPost]
        public ActionResult _GetItem([Bind(Exclude="Items")]GraphViewModel model, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                ViewModel.SelectedItem = new Item()
                {
                    
                    Id = form["SelectedItem.Id"].ToString(),
                    Name = "",
                    Price = 0,
                    BeginQuantity = Int32.Parse(form["SelectedItem.BeginQuantity"]),
                    Step = Int32.Parse(form["SelectedItem.Step"]),
                    Markup = Decimal.Parse(form["SelectedItem.Markup"]),
                    PurchasePrice = Decimal.Parse(form["SelectedItem.PurchasePrice"])
                    
                };
                
                return RedirectToAction("_GetItem", ViewModel.SelectedItem);
            }
           
            model.Items = GetListUserItems();
            return PartialView(model);
        }


        // Get list uiser items
        public IEnumerable<Item> GetListUserItems()
        {
            String userId = User.Identity.GetUserId();
            IEnumerable<Item> userItems;
            // получаем список выбранных кастомных элементов
            IEnumerable<Item> selectedCustom = repo.CustomItems
             .Where<CustomItem>(c => c.UserId == userId && (c.Chosed == true))
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
                .Where(u => u.UserId == userId),
                a => a.Id, b => b.ItemId,
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
            userItems = selectedCustom.Concat<Item>(selectedStandart).ToList<Item>();

            // Если не выбраны елементы создадим пустой елемент для отображения в списке
            if (!userItems.Any<Item>())
            {
                userItems = new Item[] { new Item() { Id = "noelement", Name = "No Element", Price = 0 } };
            }
            return userItems;

        }


       

        [HttpPost]
        public ActionResult _GetItemJSON(string val)
        {
            ViewModel.Items = GetListUserItems();
            IItem selectedItem = null;
            if (val != null)
            {
                selectedItem = ViewModel.Items.FirstOrDefault<IItem>(i => i.Id.Equals(val));
            }
            return Json(new { Succes = "true", Data = selectedItem });
        }

   
    }
}