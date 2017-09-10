﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {
        

        public IQueryable<CustomItem> CustomItems
        {
            get
            {
                return Db.CustomItems;
            }
        }

        public bool CreateCustomItem(CustomItem instance)
        {
            if (instance.Id == 0)
            {
                Db.CustomItems.InsertOnSubmit(instance);
                Db.CustomItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCustomItem(CustomItem instance)
        {
            CustomItem cache = Db.CustomItems.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for CustomItem
                Db.CustomItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveCustomItem(int idCustomItem)
        {
            CustomItem instance = Db.CustomItems.Where(p => p.Id ==
idCustomItem).FirstOrDefault();
            if (instance != null)
            {
                Db.CustomItems.DeleteOnSubmit(instance);
                Db.CustomItems.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        
    }
}