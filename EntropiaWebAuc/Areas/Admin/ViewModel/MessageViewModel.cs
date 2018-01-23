using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Admin.ViewModel
{
    public class MessageViewModel : Messages
    {
        public Messages message { get; set; }
        public Boolean IsSelected { get; set; }
    }
}