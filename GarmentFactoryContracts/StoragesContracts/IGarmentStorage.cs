using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryContracts.StoragesContracts
{
    public interface IGarmentStorage
    {
        List<GarmentViewModel> GetFullList();

        List<GarmentViewModel> GetFilteredList(GarmentBindingModel model);

        GarmentViewModel GetElement(GarmentBindingModel model);

        void Insert(GarmentBindingModel model);

        void Update(GarmentBindingModel model);

        void Delete(GarmentBindingModel model);
    }
}
