using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class GraphViewModel
    {
        
        public IEnumerable<Item> Items { get; set; }
        public Item SelectedItem { get; set; }

        public static void SaveItem(IItem item )
        {

        }
    }

    public class Item : IItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

       
        [Display(Name = "Begin Quantity")]
        public int? BeginQuantity { get; set; }

       
        [Display(Name = "Step")]
        public int? Step { get; set; }

       
        [Display(Name = "Markup")]
        public decimal? Markup { get; set; }

      
        [Display(Name = "Purchase Price")]
        public decimal? PurchasePrice { get; set; }

       
    }


}