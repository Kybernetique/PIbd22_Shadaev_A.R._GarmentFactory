using System.Collections.Generic;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryContracts.StoragesContracts
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();

        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);

        WarehouseViewModel GetElement(WarehouseBindingModel model);

        void Insert(WarehouseBindingModel model);

        void Update(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);

        bool TakeTextileFromWarehouse(Dictionary<int, (string, int)> textiles, int orderCount);
        bool CheckWriteOff(CheckWriteOffBindingModel model);
    }
}
