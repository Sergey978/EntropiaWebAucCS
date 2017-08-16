using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntropiaWebAuc.Domain.Entities
{
    [Table("CustomItems")]
    public class CustomItem
    {
        [Key]
        [DisplayName("ItemId:")]
        public int Id { get; set; }

        [DisplayName("Name:")]
        public string Name { get; set; }

        [DisplayName("Price:")]
        public decimal Price { get; set; }

        public string UserId { get; set; }

    }
}