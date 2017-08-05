using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntropiaWebAuc.Domain.Entities;
using EntropiaWebAuc.Domain.Abstract;

namespace EntropiaWebAuc.Domain.Concrete
{
    public class EFStandartItemCategoryRepo : IStadartItemCategoryRepo
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<StandartItemCategory> StandartItemCategories
        {
            get { return context.StandartItemCategories; }
        }

        public void SaveStandartItemCategory(StandartItemCategory standartItemCategory)
        {
            if (standartItemCategory.CategoryId == 0)
            {
                context.StandartItemCategories.Add(standartItemCategory);
            }
            else
            {
                StandartItemCategory dbEntry = context.StandartItemCategories.Find(standartItemCategory.CategoryId);
                if (dbEntry != null)
                {
                    dbEntry.Name = standartItemCategory.Name;
                    
                    dbEntry.ParentCategory = standartItemCategory.ParentCategory;
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