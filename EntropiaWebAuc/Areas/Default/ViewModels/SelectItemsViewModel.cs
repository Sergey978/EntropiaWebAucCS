using EntropiaWebAuc.Domain;
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

        public IEnumerable<StandartItem> SelectedStandartItems { get; set; }
        public IEnumerable<CustomItem> SelectedCustomItems { get; set; }
       
    }
}