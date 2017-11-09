using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {

        public IQueryable<RoleOption> RoleOptions
        {
            get
            {
                return Db.RoleOptions;
            }
        }
        public bool CreateRoleOption(RoleOption instance)
        {
            if (instance.Id.Equals(""))
            {
                Db.RoleOptions.InsertOnSubmit(instance);
                Db.RoleOptions.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool UpdateRoleOption(RoleOption instance)
        {
            RoleOption cache = Db.RoleOptions.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for RoleOption
                Db.RoleOptions.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool RemoveRoleOption(string idRoleOption)
        {
            RoleOption instance = Db.RoleOptions.Where(p => p.Id ==
idRoleOption).FirstOrDefault();
            if (instance != null)
            {
                Db.RoleOptions.DeleteOnSubmit(instance);
                Db.RoleOptions.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        
        
        
    }
}