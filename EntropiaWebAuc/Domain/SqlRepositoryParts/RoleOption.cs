using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {

        public IQueryable<RoleOptions> RoleOptions
        {
            get
            {
                return Db.RoleOptions;
            }
        }


        public bool CreateRoleOption(RoleOptions instance)
        {
          
                Db.RoleOptions.Add(instance);
                Db.SaveChanges();
                return true;
           
        }


        public bool UpdateRoleOption(RoleOptions instance)
        {
            RoleOptions cache = Db.RoleOptions.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for RoleOption
                cache.AmountPoints = instance.AmountPoints;
                cache.AmountCustomItems = instance.AmountCustomItems;
                cache.AmountStandartItems = instance.AmountStandartItems;
                Db.SaveChanges();
                return true;
            }

            else CreateRoleOption(instance);
            return false;
        }

        public bool RemoveRoleOption(string idRoleOption)
        {
            RoleOptions instance = Db.RoleOptions.Where(p => p.Id ==
idRoleOption).FirstOrDefault();
            if (instance != null)
            {
                Db.RoleOptions.Remove(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }
        
        
        
    }
}