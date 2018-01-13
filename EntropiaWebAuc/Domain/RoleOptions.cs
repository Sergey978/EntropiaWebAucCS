namespace EntropiaWebAuc.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoleOptions
    {
        public string Id { get; set; }

        public int? AmountPoints { get; set; }

        public int? AmountStandartItems { get; set; }

        public int? AmountCustomItems { get; set; }

        public virtual AspNetRoles AspNetRoles { get; set; }
    }
}
