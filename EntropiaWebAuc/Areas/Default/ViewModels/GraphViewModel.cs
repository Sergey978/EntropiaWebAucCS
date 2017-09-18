using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class GraphViewModel
    {
        public IEnumerable<IItem> ComplexSelectedStandartItems { get; set; }
        public IEnumerable<IItem> SelectedCustomItems { get; set; }
        public IEnumerable<IItem> Items { get; set; }
    }

    public class ComplexStandartItem : IItem
    {
             
        public int Id { get; set; }
               
        public string Name { get; set; }
              
        public decimal Price { get; set; }
                
        public int? BeginQuantity { get; set; }

        public int? Step { get; set; }

        public decimal? Markup { get; set; }

        public decimal? PurchasePrice { get; set; }
    }


    public class SelectedCustomItem : IItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? BeginQuantity { get; set; }

        public int? Step { get; set; }

        public decimal? Markup { get; set; }

        public decimal? PurchasePrice { get; set; }
    }
}