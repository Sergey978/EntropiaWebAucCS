using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Abstract;
using EntropiaWebAuc.Entities;

namespace EntropiaWebAuc.Concrete
{
    public class EfStandartItemRepository : IStandartItemRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<StandartItem> StandartItems
    {
        get { return context.StandartItems; }
    }
    }
}