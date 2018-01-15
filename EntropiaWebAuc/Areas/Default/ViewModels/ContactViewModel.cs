using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Areas.Default.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
     
    }
}