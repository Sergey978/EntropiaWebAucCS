using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {
       
        public IQueryable<StandartItem> StandartItems
        {
            get
            {
                return Db.StandartItems;
            }
        }
        public bool CreateStandartItem(StandartItem instance)
        {
            if (instance.Id == 0)
            {
                Db.StandartItems.InsertOnSubmit(instance);
                Db.StandartItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStandartItem(StandartItem instance)
        {
            StandartItem cache = Db.StandartItems.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for StandartItem
                cache.CategoryId = instance.CategoryId;
                cache.Name = instance.Name;
                cache.Price = instance.Price;                 
                Db.StandartItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public StandartItem RemoveStandartItem(int idStandartItem)
        {
            StandartItem instance = Db.StandartItems.Where(p => p.Id ==
idStandartItem).FirstOrDefault();

            if (instance != null)
            {
                Db.StandartItems.DeleteOnSubmit(instance);
                Db.StandartItems.Context.SubmitChanges();
                
            }
            return instance;
        }
        
    }
}