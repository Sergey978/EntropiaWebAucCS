using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;

namespace EntropiaWebAuc.Domain.Concrete
{
    public class EfStandartItemRepository : IStandartItemRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<StandartItem> StandartItems
    {
        get { return context.StandartItems; }
    }


        public void SaveStandartItem(StandartItem item)
        {
            if (item.ItemId == 0)
            {
                context.StandartItems.Add(item);
            }
            else
            {
                StandartItem dbEntry = context.StandartItems.Find(item.ItemId);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Price = item.Price;
                    dbEntry.Category = item.Category;
                }
            }
            context.SaveChanges();
        }

        public StandartItem DeleteStandartItem(int standartItemID)
        {
            StandartItem dbEntry = context.StandartItems.Find(standartItemID);
            if (dbEntry != null)
            {
                context.StandartItems.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}