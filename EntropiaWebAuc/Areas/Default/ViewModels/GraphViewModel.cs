using EntropiaWebAuc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class GraphViewModel
    {
        public IEnumerable<StandartItem> SelectedStandartItems { get; set; }
        public IEnumerable<CustomItem> SelectedCustomItems { get; set; }
        public IEnumerable<IItem> Items { get; set; }
    }
}