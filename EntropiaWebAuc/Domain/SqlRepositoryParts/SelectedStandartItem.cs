using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {
        
        public IQueryable<SelectedStandartItems> SelectedStandartItems
        {
            get
            {
                return Db.SelectedStandartItems;
            }
        }

        public bool CreateSelectedStandartItem(SelectedStandartItems instance)
        {
            SelectedStandartItems dbEntry = Db.SelectedStandartItems.
                FirstOrDefault(i => i.UserId == instance.UserId && i.ItemId == instance.ItemId);

            if (dbEntry == null)
            {
                Db.SelectedStandartItems.Add(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }


        public bool UpdateSelectedStandartItem(SelectedStandartItems instance)
        {
            SelectedStandartItems cache = Db.SelectedStandartItems.
                FirstOrDefault(i => i.UserId == instance.UserId && i.ItemId == instance.ItemId);
            if (cache != null)
            {
                //TODO : Update fields for SelectedStandartItem
                cache.BeginQuantity = instance.BeginQuantity;
                cache.Step = instance.Step;
                cache.Markup = instance.Markup;
                cache.PurchasePrice = instance.PurchasePrice;

                Db.SaveChanges();
                return true;
            }
            return false;
        }


        public bool RemoveSelectedStandartItem(SelectedStandartItems instance)
        {
            SelectedStandartItems cache = Db.SelectedStandartItems.
                FirstOrDefault(i => i.UserId == instance.UserId && i.ItemId == instance.ItemId);
            if (instance != null)
            {
                Db.SelectedStandartItems.Remove(cache);
                Db.SaveChanges();
                return true;
            }
            return false;
        }
        
    }
}