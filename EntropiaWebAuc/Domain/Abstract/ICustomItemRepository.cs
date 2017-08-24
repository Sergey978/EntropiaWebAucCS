using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntropiaWebAuc.Domain.Entities;

namespace EntropiaWebAuc.Domain.Abstract
{
    public interface ICustomItemRepository
    {
        IQueryable<CustomItem> CustomItems { get; }
        void SaveCustomItem(CustomItem CustomItem);
        CustomItem DeleteCustomItem(int ItemId);
        void SelectCustomItem(CustomItem customItem);
        void UnSelectCustomItem(CustomItem customItem);
    }
}
