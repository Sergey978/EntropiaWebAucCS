using EntropiaWebAuc.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.Models
{
    public class RoleModels
    {
        
        public static RoleOptions GetUserRoleOption(String userId, IRepository repo)
        {
           
            RoleOptions roleOption;

            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = userManager.FindById(userId);
                try
                {
                    var userRoleId = (from r in user.Roles select r.RoleId).First<string>();
                    roleOption = (from ro in repo.RoleOptions
                                  where ro.Id == userRoleId
                                  select ro).First();
                }
                catch (Exception ex)
                {
                    throw new Exception("User  has any roles ");
                }

            }
            return roleOption;
        }
    }
}