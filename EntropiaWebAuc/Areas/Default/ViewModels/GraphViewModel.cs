using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using Ninject;



namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class GraphViewModel
    {

        public IEnumerable<Item> Items { get; set; }
        public Item SelectedItem { get; set; }
        public int PointLimitation { get; set; }

      
    }

    public class Item : IItem
    {
        
        public string Id { get; set; }

        
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int? BeginQuantity { get; set; }

        [Required]
        [Range(1, 100000)]
        public int? Step { get; set; }

        [Required]
        [Range(typeof(decimal), "0.1", "10000")]
        public decimal? Markup { get; set; }

        [Required]
        [Range(typeof(decimal), "50.0", "10000")]
        public decimal? PurchasePrice { get; set; }

        public int? Quiantity { get; set; }


    }


}