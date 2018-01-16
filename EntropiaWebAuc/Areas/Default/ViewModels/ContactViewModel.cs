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

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }
        
        [Required]
        [StringLength(64, ErrorMessage = "The Title must be less than 64 characters long.")]
        public String Title { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "The Text must be less than 256 characters long.")]
        public String Text { get; set; }
     
    }
}