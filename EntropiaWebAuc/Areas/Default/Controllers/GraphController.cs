﻿using EntropiaWebAuc.Areas.Default.ViewModels;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace EntropiaWebAuc.Areas.Default.Controllers
{
    public class GraphController : Controller
    {
        public GraphViewModel ViewModel;

        private ICustomItemRepository customRepo;
        private IStandartItemRepository standartRepo;
        private ISelectedStandartItemRepo selectedStandartItemRepo;
        private string CurrentUserId;

          public GraphController(ICustomItemRepository custRepo,
            IStandartItemRepository standRepo,
            ISelectedStandartItemRepo selectRepo)
        {
            this.customRepo = custRepo;
            this.standartRepo = standRepo;
            this.selectedStandartItemRepo = selectRepo;
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

            return PartialView("_GetItem",ViewModel);
        }


        public void RefreshViewModel()
        {
            CurrentUserId = User.Identity.GetUserId();

            ViewModel.SelectedCustomItems = customRepo.CustomItems
             .Where<CustomItem>(c => c.UserId == CurrentUserId && (c.Chosed == true))
             .ToList();


            // select Id standart items that were selected by user
            int[] selectedStandartItemsId = selectedStandartItemRepo
                .SelectedStandartItems.Where(x => x.UserId == CurrentUserId)
                .Select(x => x.ItemId).ToArray();

            // select  standart items that were  selected
            ViewModel.SelectedStandartItems = standartRepo.StandartItems
                .Where(s => selectedStandartItemsId.Contains(s.Id));

            ViewModel.Items = ViewModel.SelectedStandartItems.Concat<IItem>(ViewModel.SelectedCustomItems);
           

        }

            
    }
}