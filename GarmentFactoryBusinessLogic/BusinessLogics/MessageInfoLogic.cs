using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace GarmentFactoryBusinessLogic.BusinessLogics
{
    public class MessageInfoLogic : IMessageInfoLogic
    {

        private readonly IMessageInfoStorage _messageInfoStorage;
        public MessageInfoLogic(IMessageInfoStorage messageInfoStorage)
        {
            _messageInfoStorage = messageInfoStorage;
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return _messageInfoStorage.GetFullList();
            }
            if (!string.IsNullOrEmpty(model.MessageId))
            {
                return new List<MessageInfoViewModel> { _messageInfoStorage.GetElement(model) };
            }
            return _messageInfoStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(MessageInfoBindingModel model)
        {
            var element = _messageInfoStorage.GetElement(new MessageInfoBindingModel
            {
                MessageId = model.MessageId
            });
            if (element != null)
            {
                _messageInfoStorage.Update(model);
            }
            else
            {
                _messageInfoStorage.Insert(model);
            }
        }
    }
}
