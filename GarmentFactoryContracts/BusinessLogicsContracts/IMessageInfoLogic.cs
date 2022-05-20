using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace GarmentFactoryContracts.BusinessLogicsContracts
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);

        void CreateOrUpdate(MessageInfoBindingModel model);
    }
}
