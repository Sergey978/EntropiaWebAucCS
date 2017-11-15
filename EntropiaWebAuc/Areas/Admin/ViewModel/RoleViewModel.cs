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
}