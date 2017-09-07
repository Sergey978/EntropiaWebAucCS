using EntropiaWebAuc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class GraphViewModel
    {
        public IEnumerable<IItem> ComplexSelectedStandartItems { get; set; }
        public IEnumerable<CustomItem> SelectedCustomItems { get; set; }
        public IEnumerable<IItem> Items { get; set; }
    }

    public class ComplexStandartItem : IItem
    {
        private int p1;
        private string p2;
        private decimal p3;
        private int? nullable1;
        private int? nullable2;
        private decimal? nullable3;
        private decimal? nullable4;

        public ComplexStandartItem(int p1, string p2, decimal p3, int? nullable1, int? nullable2, decimal? nullable3, decimal? nullable4)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.nullable1 = nullable1;
            this.nullable2 = nullable2;
            this.nullable3 = nullable3;
            this.nullable4 = nullable4;
        }
       
        public int Id { get; set; }
               
        public string Name { get; set; }
              
        public decimal Price { get; set; }
                
        public int? BeginQuantity { get; set; }

        public int? Step { get; set; }

        public decimal? Markup { get; set; }

        public decimal? PurchasePrice { get; set; }
    }
}