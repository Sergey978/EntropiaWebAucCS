namespace EntropiaWebAuc.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectedStandartItems
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        public int? BeginQuantity { get; set; }

        public int? Step { get; set; }

        public decimal? Markup { get; set; }

        public decimal? PurchasePrice { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual StandartItems StandartItems { get; set; }
    }
}
