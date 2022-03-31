using GarmentFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace GarmentFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportGarmentTextileViewModel> GarmentTextiles { get; set; }
    }
}
