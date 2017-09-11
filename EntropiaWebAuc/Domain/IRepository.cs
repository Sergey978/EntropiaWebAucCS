using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntropiaWebAuc.Domain
{
   public interface IRepository
    {
        
        #region CustomItem
        IQueryable<CustomItem> CustomItems { get; }
        bool CreateCustomItem(CustomItem instance);
        bool UpdateCustomItem(CustomItem instance);
        CustomItem RemoveCustomItem(int idCustomItem);
        #endregion 

        
        #region SelectedStandartItem
        IQueryable<SelectedStandartItem> SelectedStandartItems { get; }
        bool CreateSelectedStandartItem(SelectedStandartItem instance);
        bool UpdateSelectedStandartItem(SelectedStandartItem instance);
        bool RemoveSelectedStandartItem(SelectedStandartItem instance);
        #endregion 

        
        #region StandartItemCategory
        IQueryable<StandartItemCategory> StandartItemCategories { get; }
        bool CreateStandartItemCategory(StandartItemCategory instance);
        bool UpdateStandartItemCategory(StandartItemCategory instance);
        StandartItemCategory RemoveStandartItemCategory(int idStandartItemCategory);
        #endregion 

        
        #region StandartItem
        IQueryable<StandartItem> StandartItems { get; }
        bool CreateStandartItem(StandartItem instance);
        bool UpdateStandartItem(StandartItem instance);
        StandartItem RemoveStandartItem(int idStandartItem);
        #endregion 
        
        
        
        
    }
}
