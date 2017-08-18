using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntropiaWebAuc.Domain.Entities
{

    [Table("StandartItemCategories")]
    public class StandartItemCategory
    {
        [Key]
        [DisplayName("CategoryId:")]
        public int Id { get; set; }

        [DisplayName("Name:")]
        public string Name { get; set; }

        [DisplayName("ParentCategory:")]
        public int? ParentId{ get; set; }

        public StandartItemCategory Parent { get; set; }

        public ICollection<StandartItemCategory> Children { get; set; }

        public StandartItemCategory()
        {
            Children = new List<StandartItemCategory>();
        }


      //  public IEnumerable<StandartItem> Items { get; set; }
    }

}