using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryContracts.BusinessLogicsContracts
{
    public interface IGarmentLogic
    {
        List<GarmentViewModel> Read(GarmentBindingModel model);

        void CreateOrUpdate(GarmentBindingModel model);

        void Delete(GarmentBindingModel model);
    }
}
