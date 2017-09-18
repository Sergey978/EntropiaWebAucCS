using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {


        public IQueryable<StandartItemCategory> StandartItemCategories
        {
            get
            {
                return Db.StandartItemCategories;
            }
        }

        public bool CreateStandartItemCategory(StandartItemCategory instance)
        {
            if (instance.Id == 0)
            {
                Db.StandartItemCategories.InsertOnSubmit(instance);
                Db.StandartItemCategories.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStandartItemCategory(StandartItemCategory instance)
        {
            StandartItemCategory cache = Db.StandartItemCategories.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for StandartItemCategory
                cache.Name = instance.Name;
                cache.ParentId = instance.ParentId;
                Db.StandartItemCategories.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public StandartItemCategory RemoveStandartItemCategory(int idStandartItemCategory)
        {
            StandartItemCategory instance = Db.StandartItemCategories.Where(p => p.Id ==
idStandartItemCategory).FirstOrDefault();
            if (instance != null)
            {
                Db.StandartItemCategories.DeleteOnSubmit(instance);
                Db.StandartItemCategories.Context.SubmitChanges();
                
            }
            return instance;
        }

    }
}