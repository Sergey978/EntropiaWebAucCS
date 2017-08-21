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
    public class SelectItemsController : Controller
    {
        public ChoseItemsViewModel ViewModel;

        private ICustomItemRepository customRepo;
        private IStandartItemRepository standartRepo;
        private string CurrentUserId;
        // GET: Default/SelectItems

        public SelectItemsController(ICustomItemRepository custRepo, IStandartItemRepository standRepo )
        {
            this.customRepo = custRepo;
            this.standartRepo = standRepo;
        }

        public ActionResult Index()
        {
             CurrentUserId = User.Identity.GetUserId();

            ViewModel.StandartItems  = standartRepo.StandartItems;
            ViewModel.CustomItems = customRepo.CustomItems.Where<CustomItem>(c => c.UserId == CurrentUserId).ToList(); 

            return View(ViewModel);
        }
    }
}