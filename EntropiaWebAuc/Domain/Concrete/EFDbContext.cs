using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntropiaWebAuc.Entities;

namespace EntropiaWebAuc.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(): base("DefaultConnection")
        { }
        public DbSet<StandartItem> StandartItems { get; set; }

    }
}