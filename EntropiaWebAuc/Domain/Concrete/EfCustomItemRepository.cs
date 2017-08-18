using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain.Abstract;
using EntropiaWebAuc.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace EntropiaWebAuc.Domain.Concrete
{
    public class EfCustomItemRepository : ICustomItemRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<CustomItem> CustomItems
        {
            get
            {
                
                var items = context.CustomItems;
                return items;
            }
        }


        public void SaveCustomItem(CustomItem item)
        {
            if (item.Id == 0)
            {
                context.CustomItems.Add(item);
            }
            else
            {
                CustomItem dbEntry = context.CustomItems.Find(item.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Price = item.Price;
                    dbEntry.UserId = item.UserId;


                }
            }
            context.SaveChanges();
        }

        public CustomItem DeleteCustomItem(int CustomItemID)
        {
            CustomItem dbEntry = context.CustomItems.Find(CustomItemID);
            if (dbEntry != null)
            {
                context.CustomItems.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}