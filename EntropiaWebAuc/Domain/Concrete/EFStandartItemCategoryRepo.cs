using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain.Entities;
using EntropiaWebAuc.Domain.Abstract;
using System.Data.Entity;

namespace EntropiaWebAuc.Domain.Concrete
{
    public class EFStandartItemCategoryRepo : IStadartItemCategoryRepo
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<StandartItemCategory> StandartItemCategories
        {
            get { return context.StandartItemCategories.Include(c => c.Parent); }
        }

        public void SaveStandartItemCategory(StandartItemCategory standartItemCategory)
        {
            if (standartItemCategory.Id == 0)
            {
                context.StandartItemCategories.Add(standartItemCategory);
            }
            else
            {
                StandartItemCategory dbEntry = context.StandartItemCategories.Find(standartItemCategory.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = standartItemCategory.Name;
                    
                    dbEntry.ParentId = standartItemCategory.ParentId;
                }
            }
            context.SaveChanges();
        }

        public StandartItemCategory DeleteStandartItemCategory(int id)
        {
            StandartItemCategory dbEntry = context.StandartItemCategories.Find(id);
            if(dbEntry != null)
            {
                context.StandartItemCategories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}