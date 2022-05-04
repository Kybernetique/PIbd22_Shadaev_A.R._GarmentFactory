using System.Collections.Generic;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfoTotalOrders : PdfInfo
    {
        public List<ReportTotalOrdersViewModel> TotalOrders { get; set; }
    }
}
