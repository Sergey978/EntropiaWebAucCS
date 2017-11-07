using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain
{
    public partial class SqlRepository
    {

        

        public IQueryable<AspNetRole> AspNetRoles
        {
            get
            {
                return Db.AspNetRoles;
            }
        }
        public bool CreateAspNetRole(AspNetRole instance)
        {
            if (instance.Id.Equals(""))
            {
                Db.AspNetRoles.InsertOnSubmit(instance);
                Db.AspNetRoles.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool UpdateAspNetRole(AspNetRole instance)
        {
            AspNetRole cache = Db.AspNetRoles.Where(p => p.Id ==
instance.Id).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for AspNetRole
                Db.AspNetRoles.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool RemoveAspNetRole(string idAspNetRole)
        {
            AspNetRole instance = Db.AspNetRoles.Where(p => p.Id ==
idAspNetRole).FirstOrDefault();
            if (instance != null)
            {
                Db.AspNetRoles.DeleteOnSubmit(instance);
                Db.AspNetRoles.Context.SubmitChanges();
                return true;
            }
            return false;
        }
        
        
        
    }
}