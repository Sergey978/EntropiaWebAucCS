using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.ViewModel
{
    public class MessagesViewModel
    {
        public Messages Message{get; set;}
        public bool IsSelected { get; set; }
    }
}