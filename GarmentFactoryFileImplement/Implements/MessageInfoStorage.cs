using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {

        private readonly FileDataListSingleton source;

        public MessageInfoStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            return source.Messages
                .Select(CreateModel)
                .ToList();
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Messages.Where(rec => model.ClientId.HasValue ?
                (rec.ClientId == model.ClientId)
                :
                (model.ToSkip.HasValue && model.ToTake.HasValue || rec.DateDelivery.Date == model.DateDelivery.Date))
                .Skip(model.ToSkip ?? 0)
                .Take(model.ToTake ?? source.Messages.Count())
                .Select(CreateModel)
                .ToList();
        }
        public MessageInfoViewModel GetElement(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var message = source.Messages
                .FirstOrDefault(rec => rec.MessageId == model.MessageId);
            return message != null ? CreateModel(message) : null;
        }
        public void Insert(MessageInfoBindingModel model)
        {
            MessageInfo element = source.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null)
            {
                throw new Exception("There is already message with the same identification number");
            }
            source.Messages.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId != null ? model.ClientId : source.Clients.FirstOrDefault(rec => rec.Login == model.FromMailAddress)?.Id,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Viewed = model.Viewed
            });
        }
        public void Update(MessageInfoBindingModel model)
        {
            var element = source.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element == null)
            {
                throw new Exception("Element is not found");
            }
            CreateModel(model, element);
        }
        private MessageInfoViewModel CreateModel(MessageInfo model)
        {
            return new MessageInfoViewModel
            {
                MessageId = model.MessageId,
                SenderName = model.SenderName,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Viewed = model.Viewed,
                ReplyText = model.ReplyText
            };
        }
        private static MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.MessageId = model.MessageId;
            message.Body = model.Body;
            message.ClientId = model.ClientId;
            message.DateDelivery = model.DateDelivery;
            message.Subject = model.Subject;
            message.ReplyText = model.ReplyText;
            message.Viewed = model.Viewed;
            message.ReplyText = model.ReplyText;
            return message;
        }
    }
}
