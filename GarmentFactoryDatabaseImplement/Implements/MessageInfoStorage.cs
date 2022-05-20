using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarmentFactoryDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new GarmentFactoryDatabase();
            return context.Messages
                .Select(CreateModel)
                .ToList();
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            return context.Messages.Where(rec => model.ClientId.HasValue ?
                (rec.ClientId == model.ClientId)
                :
                (model.ToSkip.HasValue && model.ToTake.HasValue || rec.DateDelivery.Date == model.DateDelivery.Date))
                .Skip(model.ToSkip ?? 0)
                .Take(model.ToTake ?? context.Messages.Count())
                .Select(CreateModel)
                .ToList();
        }
        public MessageInfoViewModel GetElement(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            var message = context.Messages
                .FirstOrDefault(rec => rec.MessageId == model.MessageId);
            return message != null ? CreateModel(message) : null;
        }

        public void Insert(MessageInfoBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            MessageInfo element = context.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null)
            {
                throw new Exception("There is already message with the same identification number");
            }
            context.Messages.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId != null ? model.ClientId : context.Clients.FirstOrDefault(rec => rec.Login == model.FromMailAddress)?.Id,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Viewed = model.Viewed
            });
            context.SaveChanges();
        }
        public void Update(MessageInfoBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
                if (element == null)
                {
                    throw new Exception("Element is not found");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
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
            message.ClientId = model.ClientId;
            message.Subject = model.Subject;
            message.Body = model.Body;
            message.DateDelivery = model.DateDelivery;
            message.ReplyText = model.ReplyText;
            message.Viewed = model.Viewed;
            return message;
        }
    }
}
