using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {
        
        public IQueryable<CustomItems> CustomItems
        {
            get
            {
                return Db.CustomItems;
            }
        }

        public bool CreateCustomItem(CustomItems instance)
        {
            if (instance.Id == 0)
            {
            
                Db.CustomItems.Add(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCustomItem(CustomItems instance)
        {
            CustomItems cache = Db.CustomItems.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for CustomItem
                cache.BeginQuantity = instance.BeginQuantity;
                cache.Chosed = instance.Chosed;
                cache.Markup = instance.Markup;
                cache.Name = instance.Name;
                cache.Price = instance.Price;
                cache.PurchasePrice = instance.PurchasePrice;
                cache.Step = instance.Step;
                Db.SaveChanges();
                
                return true;
            }
            return false;
        }

        public CustomItems RemoveCustomItem(int idCustomItem)
        {
            CustomItems instance = Db.CustomItems.Where(p => p.Id ==
idCustomItem).FirstOrDefault();
            if (instance != null)
            {
                Db.CustomItems.Remove(instance);
                Db.SaveChanges();
               
            }
            return instance;
        }
        
    }
}