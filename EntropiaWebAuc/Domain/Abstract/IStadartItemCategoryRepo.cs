using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntropiaWebAuc.Domain.Entities;

namespace EntropiaWebAuc.Domain.Abstract
{
   public interface IStadartItemCategoryRepo
    {
        IQueryable<StandartItemCategory> StandartItemCategories { get; }
        void SaveStandartItemCategory(StandartItemCategory standartItemCategory);
        StandartItemCategory DeleteStandartItemCategory(int CategoryId);
    }
}
