using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;
using System.Data.Entity;

namespace EntropiaWebAuc.Domain.Concrete
{
    public class EFSelectedStandartItemRepo : ISelectedStandartItemRepo
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.SelectedStandartItem> SelectedStandartItems
        {
            get
            {
                var items = context.SelectedStandartItems;
                return items;
            }
        }

        public void SaveSelectedStandartItem(Entities.SelectedStandartItem item)
        {
            if (item.Id == 0)
            {
                context.SelectedStandartItems.Add(item);
            }
            else
            {
                SelectedStandartItem dbEntry = context.SelectedStandartItems.Find(item.Id);
                if (dbEntry != null)
                {
                    
                    dbEntry.ItemId = item.ItemId;
                    dbEntry.UserId = item.UserId;
                }
            }
            context.SaveChanges();
        }

        public Entities.SelectedStandartItem DeleteSelectedStandartItem(int ItemId)
        {
            SelectedStandartItem dbEntry = context.SelectedStandartItems.Find(ItemId);
            if (dbEntry != null)
            {
                context.SelectedStandartItems.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;

        }
    }
}