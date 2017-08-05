using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntropiaWebAuc.Domain.Entities
{

    [Table("StandartItemCategories")]
    public class StandartItemCategory
    {
        [Key]
        [DisplayName("CategoryId:")]
        public int CategoryId { get; set; }

        [DisplayName("Name:")]
        public string Name { get; set; }

        [DisplayName("ParentCategory:")]
        public int ParentCategory { get; set; }
    }

}