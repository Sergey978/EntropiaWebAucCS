using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Areas.Default.ViewModels;
using EntropiaWebAuc.Domain.Entities;
using EntropiaWebAuc.Domain.Abstract;
using Microsoft.AspNet.Identity;
using System.Data.Entity;


namespace EntropiaWebAuc.Areas.Default.Controllers
{
    [Authorize]
    public class SelectItemsController : Controller
    {
        public SelectItemsViewModel ViewModel;

        private ICustomItemRepository customRepo;
        private IStandartItemRepository standartRepo;
        private string CurrentUserId;
        // GET: Default/SelectItems

        public SelectItemsController(ICustomItemRepository custRepo, IStandartItemRepository standRepo )
        {
            this.customRepo = custRepo;
            this.standartRepo = standRepo;
            this.ViewModel = new SelectItemsViewModel();
        }

        public ActionResult Index()
        {
             CurrentUserId = User.Identity.GetUserId();
            // select all standart items 
            ViewModel.StandartItems  = standartRepo.StandartItems;

            // select standart items selected by user

        //    ViewModel.SelectedStandartItem = standartRepo.StandartItems
        //        .Where<StandartItem>(item => item.)
            // select custom items that were not selected
            ViewModel.CustomItems = customRepo.CustomItems
                .Where<CustomItem>(c => c.UserId == CurrentUserId && !(c.Chosed ?? false))
                .ToList();
 
            //select custom items that were selected

            ViewModel.SelectedCustomItem = customRepo.CustomItems
               .Where<CustomItem>(c => c.UserId == CurrentUserId && (c.Chosed == true))
               .ToList();

            return View(ViewModel);
        }
    }
}