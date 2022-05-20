using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace GarmentFactoryContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);

        MessageInfoViewModel GetElement(MessageInfoBindingModel model);

        void Insert(MessageInfoBindingModel model);

        void Update(MessageInfoBindingModel model);

    }
}
