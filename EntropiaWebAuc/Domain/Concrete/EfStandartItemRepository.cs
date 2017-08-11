using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;
using System.Data.Entity;


namespace EntropiaWebAuc.Domain.Concrete
{
    public class EfStandartItemRepository : IStandartItemRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<StandartItem> StandartItems
    {
        get { 
            var items = context.StandartItems.Include( c => c.Category);
            return items;
        }
    }


        public void SaveStandartItem(StandartItem item)
        {
            if (item.Id == 0)
            {
                context.StandartItems.Add(item);
            }
            else
            {
                StandartItem dbEntry = context.StandartItems.Find(item.Id);
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