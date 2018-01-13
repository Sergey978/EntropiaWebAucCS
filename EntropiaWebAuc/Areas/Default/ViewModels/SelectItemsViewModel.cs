using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class SelectItemsViewModel
    {
        public IEnumerable<StandartItems> StandartItems {get; set;}
        public IEnumerable<CustomItems> CustomItems { get; set; }

        public IEnumerable<StandartItems> SelectedStandartItems { get; set; }
        public IEnumerable<CustomItems> SelectedCustomItems { get; set; }
       
    }
}