using System.Collections.Generic;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfoWarehouses : ExcelInfo
    {
        public List<ReportWarehouseTextileViewModel> WarehouseTextiles { get; set; }
    }
}
