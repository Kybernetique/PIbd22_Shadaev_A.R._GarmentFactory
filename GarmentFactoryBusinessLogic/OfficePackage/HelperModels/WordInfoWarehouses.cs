using System.Collections.Generic;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfoWarehouses : WordInfo
    {
        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
