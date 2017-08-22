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
        
            [Key]
            public int Id { get; set; }
            public string UserId { get; set; }
            public int ItemId { get; set; }
          
    }
}