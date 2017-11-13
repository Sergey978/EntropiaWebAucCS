using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Admin.ViewModel
{
    public class RoleViewModel
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public int? NumberPoint { get; set; }
        public int? NumberStandartItems { get; set; }
        public int? NumberCustomItems { get; set; }
    }
}