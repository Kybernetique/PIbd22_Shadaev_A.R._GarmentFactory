using GarmentFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace GarmentFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<GarmentViewModel> Garments { get; set; }
    }
}
