using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {
       
        public IQueryable<StandartItems> StandartItems
        {
            get
            {
                return Db.StandartItems;
            }
        }
        public bool CreateStandartItem(StandartItems instance)
        {
            if (instance.Id == 0)
            {
                Db.StandartItems.Add(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStandartItem(StandartItems instance)
        {
            StandartItems cache = Db.StandartItems.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for StandartItem
                cache.CategoryId = instance.CategoryId;
                cache.Name = instance.Name;
                cache.Price = instance.Price;                 
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public StandartItems RemoveStandartItem(int idStandartItem)
        {
            StandartItems instance = Db.StandartItems.Where(p => p.Id ==
idStandartItem).FirstOrDefault();

            if (instance != null)
            {
                Db.StandartItems.Remove(instance);
                Db.SaveChanges();
                
            }
            return instance;
        }
        
    }
}