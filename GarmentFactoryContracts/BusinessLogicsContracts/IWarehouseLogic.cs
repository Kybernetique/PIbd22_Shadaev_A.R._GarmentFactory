using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace GarmentFactoryContracts.BusinessLogicsContracts
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> Read(WarehouseBindingModel model);

        void CreateOrUpdate(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);

        void AddTextile(WarehouseBindingModel model, int textileId, int count);
    }
}
