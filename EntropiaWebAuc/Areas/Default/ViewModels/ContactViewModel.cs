using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class ContactViewModel
    {
        int Id { get; set; }
        String Name { get; set; }
        String Email { get; set; }
        String Title { get; set; }
        String Text { get; set; }
    }
}