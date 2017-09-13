using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain;


namespace EntropiaWebAuc.Areas.Admin.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int? ParentIdP { get; set; }
        public String ParentName { get; set; }

    }

    }


}