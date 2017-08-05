using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntropiaWebAuc.Domain.Entities;

namespace EntropiaWebAuc.Domain.Abstract
{
    public interface IStandartItemRepository
    {
        IQueryable<StandartItem> StandartItems { get; }
        void SaveStandartItem(StandartItem standartItem);
        StandartItem DeleteStandartItem(int ItemId);
    }
}
