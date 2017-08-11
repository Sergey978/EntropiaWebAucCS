using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntropiaWebAuc.Domain.Entities;
using System.Web.Mvc;


namespace EntropiaWebAuc.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(): base("DefaultConnection")
        { }
        public DbSet<StandartItem> StandartItems { get; set; }
        public DbSet<StandartItemCategory> StandartItemCategories { get; set; }

    }
}