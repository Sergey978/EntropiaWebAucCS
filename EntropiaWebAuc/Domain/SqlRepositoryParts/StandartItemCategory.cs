using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {


        public IQueryable<StandartItemCategories> StandartItemCategories
        {
            get
            {
                return Db.StandartItemCategories;
            }
        }

        public bool CreateStandartItemCategory(StandartItemCategories instance)
        {
            if (instance.Id == 0)
            {
                Db.StandartItemCategories.Add(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStandartItemCategories(StandartItemCategories instance)
        {
            StandartItemCategories cache = Db.StandartItemCategories.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for StandartItemCategories
                cache.Name = instance.Name;
                cache.ParentId = instance.ParentId;
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public StandartItemCategories RemoveStandartItemCategory(int idStandartItemCategory)
        {
            StandartItemCategories instance = Db.StandartItemCategories.Where(p => p.Id ==
idStandartItemCategory).FirstOrDefault();
            if (instance != null)
            {
                Db.StandartItemCategories.Remove(instance);
                Db.SaveChanges();
                
            }
            return instance;
        }

    }
}