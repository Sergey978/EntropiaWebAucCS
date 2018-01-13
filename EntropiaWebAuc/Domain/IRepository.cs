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
        IQueryable<CustomItems> CustomItems { get; }
        bool CreateCustomItem(CustomItems instance);
        bool UpdateCustomItem(CustomItems instance);
        CustomItems RemoveCustomItem(int idCustomItem);
        #endregion 

        
        #region SelectedStandartItem
        IQueryable<SelectedStandartItems> SelectedStandartItems { get; }
        bool CreateSelectedStandartItem(SelectedStandartItems instance);
        bool UpdateSelectedStandartItem(SelectedStandartItems instance);
        bool RemoveSelectedStandartItem(SelectedStandartItems instance);
        #endregion 

        
        #region StandartItemCategory
        IQueryable<StandartItemCategories> StandartItemCategories { get; }
        bool CreateStandartItemCategory(StandartItemCategories instance);
        bool UpdateStandartItemCategories(StandartItemCategories instance);
        StandartItemCategories RemoveStandartItemCategory(int idStandartItemCategory);
        #endregion 

        
        #region StandartItem
        IQueryable<StandartItems> StandartItems { get; }
        bool CreateStandartItem(StandartItems instance);
        bool UpdateStandartItem(StandartItems instance);
        StandartItems RemoveStandartItem(int idStandartItem);
        #endregion 
        
        
        #region RoleOptions
        IQueryable<RoleOptions> RoleOptions { get; }
        bool CreateRoleOption(RoleOptions instance);
        bool UpdateRoleOption(RoleOptions instance);
        bool RemoveRoleOption(String Id);
        #endregion 
        
        
        
        
    }
}
