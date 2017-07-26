using System.Linq;
using EntropiaWebAuc.Entities;

namespace EntropiaWebAuc.Abstract
{
    public interface IStandartItemRepository
    {
        IQueryable<StandartItem> StandartItems { get; }
    }
}
