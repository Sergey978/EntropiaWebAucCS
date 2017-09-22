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
        public ActionResult Index()
        {

            return View();
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
            ViewModel.SelectedCustomItems = repo.CustomItems
             .Where<CustomItem>(c => c.UserId == CurrentUserId && (c.Chosed == true))
             .Select(item => new SelectedCustomItem()
             {
                 Id = "custom-" + item.Id.ToString() ,
                 Name = item.Name,
                 Price = item.Price,
                 BeginQuantity = item.BeginQuantity,
                 Step = item.Step,
                 Markup = item.Markup,
                 PurchasePrice = item.PurchasePrice
             });
            // select standart items that user has choise
            ViewModel.ComplexSelectedStandartItems =
                repo.StandartItems.Join(repo.SelectedStandartItems
                .Where(u =>u.UserId == CurrentUserId),
                a => a.Id, b => b.ItemId , 
                (a, b) => new ComplexStandartItem()
                {
                    Id = "standart-" + a.Id.ToString(),
                    Name = a.Name,
                    Price = a.Price,
                    BeginQuantity = b.BeginQuantity,
                    Step = b.Step,
                    Markup = b.Markup,
                    PurchasePrice = b.PurchasePrice
                });

              ViewModel.Items = ViewModel.ComplexSelectedStandartItems.Concat<IItem>(ViewModel.SelectedCustomItems);
            
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
        public ActionResult Calc()
        {
            return Index();
        }



    }
}