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
        private ISelectedStandartItemRepo selectedStandartItemRepo;
        private string CurrentUserId;
        // GET: Default/SelectItems

        public SelectItemsController(ICustomItemRepository custRepo,
            IStandartItemRepository standRepo,
            ISelectedStandartItemRepo selectRepo)
        {
            this.customRepo = custRepo;
            this.standartRepo = standRepo;
            this.selectedStandartItemRepo = selectRepo;
            this.ViewModel = new SelectItemsViewModel();
        }

        public ActionResult Index()
        {
            CurrentUserId = User.Identity.GetUserId();

            // select Id standart items that were selected by user
            int[] selectedStandartItemsId = selectedStandartItemRepo
                .SelectedStandartItems.Where(x => x.UserId == CurrentUserId)
                .Select(x => x.ItemId).ToArray();


            // select  standart items that were not selected
            ViewModel.StandartItems = standartRepo.StandartItems
                .Where(s => !selectedStandartItemsId.Contains(s.Id));



            // select  standart items that were  selected
            ViewModel.SelectedStandartItems = standartRepo.StandartItems
                .Where(s => selectedStandartItemsId.Contains(s.Id));


            // select custom items that were not selected
            ViewModel.CustomItems = customRepo.CustomItems
                .Where<CustomItem>(c => c.UserId == CurrentUserId && !(c.Chosed ?? false))
                .ToList();

            //select custom items that were selected

            ViewModel.SelectedCustomItems = customRepo.CustomItems
               .Where<CustomItem>(c => c.UserId == CurrentUserId && (c.Chosed == true))
               .ToList();

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult CustomItemSelect(FormCollection formCollection)
        {
            string[] selectedItems = new string[] { };
            if (formCollection["CustomItems"] != null)
            {
                selectedItems = formCollection["CustomItems"].Split(',');
            }


            foreach (string itemId in selectedItems)
            {
                int id = Int32.Parse(itemId);

                CustomItem selectedCustomItem =
                    customRepo.CustomItems
                    .FirstOrDefault<CustomItem>(c => c.Id == id);

                customRepo.SelectCustomItem(selectedCustomItem);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult CustomItemUnSelect(FormCollection formCollection)
        {

            string[] selectedItems = new string[] { };

            if (formCollection["SelectedCustomItems"] != null)
            {
                selectedItems = formCollection["SelectedCustomItems"].Split(',');
            }


            foreach (string itemId in selectedItems)
            {
                int id = Int32.Parse(itemId);

                CustomItem selectedCustomItem =
                    customRepo.CustomItems
                    .FirstOrDefault<CustomItem>(c => c.Id == id);

                customRepo.UnSelectCustomItem(selectedCustomItem);
            }

            return RedirectToAction("Index");
        }
    }
}