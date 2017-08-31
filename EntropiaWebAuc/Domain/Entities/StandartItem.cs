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
    public class StandartItem : IItem
    {
        [Key]
        [Required]
        [DisplayName("ItemId:")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name:")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0,00", "500,99")]
        [DisplayName("Price:")]
        public decimal Price { get; set; }

        [DisplayName("Markup:")]
        public decimal Markup { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

       public int? CategoryId { get; set; }


        [DisplayName("Category:")]
        public virtual  StandartItemCategory Category { get; set; }

        

    }
}