using System.Collections.Generic;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryContracts.BusinessLogicsContracts
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);

        void CreateOrUpdate(ClientBindingModel model);

        void Delete(ClientBindingModel model);
    }
}
