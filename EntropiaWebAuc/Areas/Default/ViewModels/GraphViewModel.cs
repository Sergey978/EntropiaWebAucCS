using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using EntropiaWebAuc.Domain;


namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class GraphViewModel
    {

        public IEnumerable<Item> Items { get; set; }
        public Item SelectedItem { get; set; }

        private IRepository repo;

        public  void SaveItem (IItem item, String userId)
        {
            String  typeItem = item.Id.Split('-')[0];
            int id = Int32.Parse(item.Id.Split('-')[1]);

            if (typeItem.Equals("custom"))
            {

                CustomItem cache = repo.CustomItems.FirstOrDefault<CustomItem>(c => c.Id == id);

                cache.BeginQuantity = item.BeginQuantity;
                cache.Step = item.Step;
                cache.Markup = item.Markup;
                cache.PurchasePrice = item.PurchasePrice;

                repo.UpdateCustomItem(cache);
            }
            else if(typeItem.Equals("standart"))
            {
                St

            }

             

        }
    }

    public class Item : IItem
    {
        
        public string Id { get; set; }

        
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int? BeginQuantity { get; set; }

        [Required]
        public int? Step { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "10000")]
        public decimal? Markup { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "10000")]
        public decimal? PurchasePrice { get; set; }


    }


}