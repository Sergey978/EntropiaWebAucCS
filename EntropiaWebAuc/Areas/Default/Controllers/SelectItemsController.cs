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

            return View();
        }

        //   [HttpPost]
        public PartialViewResult CustomItemSelect(FormCollection formCollection, String Command)
        {
            string[] selectedItems = new string[] { };
            if (Command == " ==> ")
            {
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
            }

            if (Command == " <== ")
            {
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

            }

            RefreshViewModelCustomItems();
            return PartialView("_GetCustomItems", ViewModel);
        }



        [HttpPost]
        public PartialViewResult StandartItemSelect(FormCollection formCollection, String Command)
        {
            CurrentUserId = User.Identity.GetUserId();
            string[] selectedItems = new string[] { };
           

            if (Command == " ==> ")
            {
                if (formCollection["StandartItems"] != null)
                {
                    selectedItems = formCollection["StandartItems"].Split(',');
                }
                foreach (string itemId in selectedItems)
                {
                    int id = Int32.Parse(itemId);

                    SelectedStandartItem selectedStandartItem =
                        new SelectedStandartItem() { UserId = CurrentUserId, ItemId = id };

                    selectedStandartItemRepo.SaveSelectedStandartItem(selectedStandartItem);
                }

            }

            if (Command == " <== ")
            {
                if (formCollection["SelectedStandartItems"] != null)
                {
                    selectedItems = formCollection["SelectedStandartItems"].Split(',');
                }
                foreach (string itemId in selectedItems)
                {
                    int id = Int32.Parse(itemId);

                    SelectedStandartItem selectedStandartItem =
                        selectedStandartItemRepo.SelectedStandartItems
                        .FirstOrDefault(i => i.UserId == CurrentUserId && i.ItemId == id);

                    selectedStandartItemRepo.DeleteSelectedStandartItem(selectedStandartItem);
                }

            }

            RefreshViewModelStandartItems();
            return PartialView("_GetStandartItems", ViewModel);
        }

      

        public PartialViewResult _GetCustomItems()
        {
            RefreshViewModelCustomItems();
            return PartialView(ViewModel);
        }

        public PartialViewResult _GetStandartItems()
        {
            RefreshViewModelStandartItems();
            return PartialView(ViewModel);
        }

        private void RefreshViewModelStandartItems()
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
        }

        private void RefreshViewModelCustomItems()
        {
            CurrentUserId = User.Identity.GetUserId();

            // select custom items that were not selected
            ViewModel.CustomItems = customRepo.CustomItems
                .Where<CustomItem>(c => c.UserId == CurrentUserId && !(c.Chosed ?? false))
                .ToList();

            //select custom items that were selected

            ViewModel.SelectedCustomItems = customRepo.CustomItems
               .Where<CustomItem>(c => c.UserId == CurrentUserId && (c.Chosed == true))
               .ToList();
        }
    }
}