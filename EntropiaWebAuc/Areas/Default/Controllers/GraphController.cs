using EntropiaWebAuc.Areas.Default.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using EntropiaWebAuc.Domain;
using Ninject;

namespace EntropiaWebAuc.Areas.Default.Controllers
{
    [Authorize]
    public class GraphController : Controller
    {
        public GraphViewModel ViewModel;

        [Inject]
        public IRepository Repo {get; set;}

        public GraphController()
        {
            
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
                    Name = model.SelectedItem.Name,
                    Price = model.SelectedItem.Price,
                    BeginQuantity = Int32.Parse(form["SelectedItem.BeginQuantity"]),
                    Step = Int32.Parse(form["SelectedItem.Step"]),
                    Markup = Decimal.Parse(form["SelectedItem.Markup"]),
                    PurchasePrice = Decimal.Parse(form["SelectedItem.PurchasePrice"])
                    
                };
               SaveItem(ViewModel.SelectedItem, User.Identity.GetUserId());
                
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
            IEnumerable<Item> selectedCustom = Repo.CustomItems
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
                Repo.StandartItems.Join(Repo.SelectedStandartItems
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

        public void SaveItem(IItem item, String userId)
        {

            String typeItem = item.Id.Split('-')[0];
            int id = Int32.Parse(item.Id.Split('-')[1]);


            if (typeItem.Equals("custom"))
            {

                CustomItem cache = Repo.CustomItems.FirstOrDefault<CustomItem>(c => c.Id == id);

                cache.BeginQuantity = item.BeginQuantity;
                cache.Step = item.Step;
                cache.Markup = item.Markup;
                cache.PurchasePrice = item.PurchasePrice;

                Repo.UpdateCustomItem(cache);
            }
            else if (typeItem.Equals("standart"))
            {
                SelectedStandartItem cache = Repo.SelectedStandartItems
                    .FirstOrDefault<SelectedStandartItem>
                    (c => c.ItemId == id && c.UserId == userId);

                cache.BeginQuantity = item.BeginQuantity;
                cache.Step = item.Step;
                cache.Markup = item.Markup;
                cache.PurchasePrice = item.PurchasePrice;

                Repo.UpdateSelectedStandartItem(cache);

            }



        }

   
    }
}