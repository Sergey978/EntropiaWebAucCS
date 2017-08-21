using EntropiaWebAuc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class ChoseItemsViewModel
    {
        public IEnumerable<StandartItem> StandartItems {get; set;}
        public IEnumerable<CustomItem> CustomItems { get; set; }
    }
}