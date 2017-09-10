using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {
        
        public IQueryable<SelectedStandartItem> SelectedStandartItems
        {
            get
            {
                return Db.SelectedStandartItems;
            }
        }

        public bool CreateSelectedStandartItem(SelectedStandartItem instance)
        {
            SelectedStandartItem dbEntry = Db.SelectedStandartItems.
                FirstOrDefault(i => i.UserId == instance.UserId && i.ItemId == instance.ItemId);

            if (dbEntry == null)
            {
                Db.SelectedStandartItems.InsertOnSubmit(instance);
                Db.SelectedStandartItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool UpdateSelectedStandartItem(SelectedStandartItem instance)
        {
            SelectedStandartItem cache = Db.SelectedStandartItems.
                FirstOrDefault(i => i.UserId == instance.UserId && i.ItemId == instance.ItemId);
            if (cache != null)
            {
                //TODO : Update fields for SelectedStandartItem
                Db.SelectedStandartItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool RemoveSelectedStandartItem(SelectedStandartItem instance)
        {
            SelectedStandartItem cache = Db.SelectedStandartItems.
                FirstOrDefault(i => i.UserId == instance.UserId && i.ItemId == instance.ItemId);
            if (instance != null)
            {
                Db.SelectedStandartItems.DeleteOnSubmit(cache);
                Db.SelectedStandartItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        
    }
}