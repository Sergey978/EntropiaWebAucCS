namespace EntropiaWebAuc.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomItems
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public bool? Chosed { get; set; }

        public int? BeginQuantity { get; set; }

        public decimal? Markup { get; set; }

        public decimal? PurchasePrice { get; set; }

        public int? Step { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
