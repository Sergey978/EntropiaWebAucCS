using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain.Entities;
using System.Web.Mvc;

namespace EntropiaWebAuc.Areas.Admin.ViewModels
{
    public class StandartItemEditViewModel
    {
        public StandartItem Item { get; set; }
        public SelectList Categories { get; set; }
    }
}