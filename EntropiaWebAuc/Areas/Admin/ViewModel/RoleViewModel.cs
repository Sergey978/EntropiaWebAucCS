using EntropiaWebAuc.Areas.Default.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Admin.ViewModel
{
    public class RoleViewModel
    {
        public String Id { get; set; }
        public String Name { get; set; }

        [DisplayName("Number Points")]
        public int? NumberPoint { get; set; }
        [DisplayName("Number Standart Items")]
        public int? NumberStandartItems { get; set; }
        [DisplayName("Number Custom Items")]
        public int? NumberCustomItems { get; set; }
    }

    public class UsersRoles
    {
        public ApplicationUser User { get; set; }
        public IdentityUserRole Role { get; set; }
        public Boolean selected { get; set; }
    }

}