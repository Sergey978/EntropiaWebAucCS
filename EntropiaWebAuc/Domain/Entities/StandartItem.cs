using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntropiaWebAuc.Domain.Entities
{
    [Table("StandartItems")]
    public class StandartItem
    {
        [Key]
        [ForeignKey("Category")]
        [DisplayName("ItemId:")]
        public int ItemId { get; set; }

        [DisplayName("Name:")]
        public string Name { get; set; }

        [DisplayName("Price:")]
        public decimal Price { get; set; }

       public int? CategoryId { get; set; }

        [DisplayName("Category:")]
        public virtual  StandartItemCategory Category { get; set; }

    }
}