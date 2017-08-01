using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntropiaWebAuc.Entities
{
    [Table("StandartItems")]
    public class StandartItem
    {
        [Key]
        [DisplayName("ItemId:")]
        public int ItemId { get; set; }

        [DisplayName("Name:")]
        public string Name { get; set; }

        [DisplayName("Price:")]
        public decimal Price { get; set; }

        [DisplayName("Category:")]
        public string Category { get; set; }

    }
}