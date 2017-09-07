using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNet.Identity;

namespace EntropiaWebAuc.Domain.Entities
{
    [Table("CustomItems")]
    public class CustomItem : IItem
    {
        [Key]
        [DisplayName("ItemId:")]
        public int Id { get; set; }

        [DisplayName("Name:")]
        public string Name { get; set; }

        [DisplayName("Price:")]
        public decimal Price { get; set; }

        [DisplayName("Markup:")]
        public decimal Markup { get; set; }

        public string UserId { get; set; }

        public bool? Chosed { get; set; }

        public int? BeginQuantity { get; set; }

        public decimal? PurchasePrice { get; set; }

        public int? Step { get; set; }

    }
}