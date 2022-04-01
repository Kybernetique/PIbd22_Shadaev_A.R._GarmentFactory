using System.Collections.Generic;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryContracts.StoragesContracts
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();
        List<ClientViewModel> GetFilteredList(ClientBindingModel model);
        ClientViewModel GetElement(ClientBindingModel model);
        void Insert(ClientBindingModel model);
        void Update(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
