using EntropiaWebAuc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class SelectItemsViewModel
    {
        public IEnumerable<StandartItem> StandartItems {get; set;}
        public IEnumerable<CustomItem> CustomItems { get; set; }

        public IEnumerable<StandartItem> SelectedStandartItem { get; set; }
        public IEnumerable<CustomItem> SelectedCustomItem { get; set; }
    }
}