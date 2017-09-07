using EntropiaWebAuc.Areas.Default.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntropiaWebAuc.Domain.Entities
{
    [Table("SelectedStandartItems")]
    public class SelectedStandartItem
    {

        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        public int ItemId { get; set; }
        public int? BeginQuantity { get; set; }
        public int? Step { get; set; }
        public decimal? Markup { get; set; }
        public decimal? PurchasePrice { get; set; }

    }
}