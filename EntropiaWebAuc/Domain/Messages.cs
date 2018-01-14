namespace EntropiaWebAuc.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Messages
    {
        
        public long Id { get; set; }

        [StringLength(128)]
        public string SenderId { get; set; }

        [StringLength(50)]
        public string SenderEmail { get; set; }

        [StringLength(50)]
        public string SenderName { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Date { get; set; }

        [Required]
        [StringLength(128)]
        public string RecId { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(512)]
        public string Text { get; set; }

        public bool? Sent { get; set; }

        public bool? Read { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
