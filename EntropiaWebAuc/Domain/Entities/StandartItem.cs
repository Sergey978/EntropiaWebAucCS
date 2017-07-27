using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntropiaWebAuc.Entities
{
    [Table("StandartItems")]
    public class StandartItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}