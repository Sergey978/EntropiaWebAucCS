using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Areas.Default.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using EntropiaWebAuc.Domain;
using EntropiaWebAuc.Areas.Default.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace EntropiaWebAuc.Areas.Default.Controllers
{
    [Authorize]
    public class SelectItemsController : Controller
    {
        public SelectItemsViewModel ViewModel;

        private IRepository repo;

        private string CurrentUserId;
        // GET: Default/SelectItems

        public SelectItemsController(IRepository repo)
        {
            this.repo = repo;
            this.ViewModel = new SelectItemsViewModel();
        }

        public ActionResult Index()
        {

            return View();
        }

        //   [HttpPost]
        public PartialViewResult CustomItemSelect(FormCollection formCollection, String Command)
        {
            RoleOptions roleOption = RoleModels.GetUserRoleOption(User.Identity.GetUserId(), repo);
            string[] selectedItems = new string[] { };
            if (Command == " ==> ")
            {
                if (formCollection["CustomItems"] != null)
                {
                    selectedItems = formCollection["CustomItems"].Split(',');
                }

                // проверка сколько количества кастом итемов у пользователя 
                int currentCountItems = (from custom in repo.CustomItems
                                         where custom.AspNetUsers.Id == CurrentUserId
                                         && custom.Chosed == true
                                         select custom).Count();

                if ((currentCountItems + selectedItems.Count()) <= roleOption.AmountCustomItems)
                {
                    foreach (string itemId in selectedItems)
                    {
                        int id = Int32.Parse(itemId);

                        CustomItems selectedCustomItem =
                            repo.CustomItems
                            .FirstOrDefault<CustomItems>(c => c.Id == id);
                        selectedCustomItem.Chosed = true;

                        repo.UpdateCustomItem(selectedCustomItem);
                    }

                }
                else
                {
                    // to do 
                    // message exceeding the limit for custom items

                    ViewBag.message = "Exceeded the limit of custom items for your status";
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

                    CustomItems selectedCustomItem =
                        repo.CustomItems
                        .FirstOrDefault<CustomItems>(c => c.Id == id);
                    selectedCustomItem.Chosed = false;

                    repo.UpdateCustomItem(selectedCustomItem);
                }

            }

            RefreshViewModelCustomItems();

            return PartialView("_GetCustomItems", ViewModel);
        }



        [HttpPost]
        public PartialViewResult StandartItemSelect(FormCollection formCollection, String Command)
        {
            CurrentUserId = User.Identity.GetUserId();
            RoleOptions roleOption = RoleModels.GetUserRoleOption(User.Identity.GetUserId(), repo);
            string[] selectedItems = new string[] { };


            if (Command == " ==> ")
            {
                if (formCollection["StandartItems"] != null)
                {
                    selectedItems = formCollection["StandartItems"].Split(',');
                }

                // check how many items user can hold
                int currentCountStandart = (from st in repo.SelectedStandartItems
                                            where st.UserId == CurrentUserId
                                            select st).Count();
                if ((currentCountStandart + selectedItems.Count()) <= roleOption.AmountStandartItems)
                {
                    foreach (string itemId in selectedItems)
                    {
                        int id = Int32.Parse(itemId);

                        SelectedStandartItems selectedStandartItem =
                            new SelectedStandartItems() { UserId = CurrentUserId, ItemId = id };

                        repo.CreateSelectedStandartItem(selectedStandartItem);
                    }
                }
                else
                {

                    // message exceeding the limit for custom items

                    ViewBag.message = "Exceeded the limit of standart items for your status";
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

                    SelectedStandartItems selectedStandartItem =
                        repo.SelectedStandartItems
                        .FirstOrDefault(i => i.UserId == CurrentUserId && i.ItemId == id);

                    repo.RemoveSelectedStandartItem(selectedStandartItem);
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
            int[] selectedStandartItemsId = repo
                .SelectedStandartItems.Where(x => x.UserId == CurrentUserId)
                .Select(x => x.ItemId).ToArray();


            // select  standart items that were not selected
            ViewModel.StandartItems = repo.StandartItems
                .Where(s => !selectedStandartItemsId.Contains(s.Id));



            // select  standart items that were  selected
            ViewModel.SelectedStandartItems = repo.StandartItems
                .Where(s => selectedStandartItemsId.Contains(s.Id));
        }

        private void RefreshViewModelCustomItems()
        {
            CurrentUserId = User.Identity.GetUserId();

            // select custom items that were not selected
            ViewModel.CustomItems = repo.CustomItems
                .Where<CustomItems>(c => c.UserId == CurrentUserId && !(c.Chosed ?? false))
                .ToList();

            //select custom items that were selected

            ViewModel.SelectedCustomItems = repo.CustomItems
               .Where<CustomItems>(c => c.UserId == CurrentUserId && (c.Chosed == true))
               .ToList();
        }

        
    }
}