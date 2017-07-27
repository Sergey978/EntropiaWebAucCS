using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntropiaWebAuc.Entities;

namespace EntropiaWebAuc.Abstract
{
    public interface IStandartItemRepository
    {
        IQueryable<StandartItem> StandartItems { get; }
    }
}
