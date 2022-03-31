using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarmentFactoryDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            GarmentFactoryDatabase context = new GarmentFactoryDatabase();
            return context.Orders.Include(rec => rec.Garment)
                .Select(CreateModel)
                .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            GarmentFactoryDatabase context = new GarmentFactoryDatabase();
            return context.Orders.Include(rec => rec.Garment)
                .Where(rec => rec.GarmentId == model.GarmentId || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date
                && rec.DateCreate.Date <= model.DateTo.Value.Date))
                .Select(CreateModel)
                .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            GarmentFactoryDatabase context = new GarmentFactoryDatabase();
            Order order = context.Orders.Include(rec => rec.Garment)
                 .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ?
            new OrderViewModel
            {
                Id = order.Id,
                GarmentId = order.GarmentId,
                GarmentName = order.Garment.GarmentName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
            } :
            null;
        }
        public void Insert(OrderBindingModel model)
        {
            GarmentFactoryDatabase context = new GarmentFactoryDatabase();
            Order order = new Order
            {
                GarmentId = model.GarmentId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
            };
            context.Orders.Add(order);
            context.SaveChanges();
            CreateModel(model, order);
            context.SaveChanges();
        }
        public void Update(OrderBindingModel model)
        {
            GarmentFactoryDatabase context = new GarmentFactoryDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.GarmentId = model.GarmentId;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateCreate = model.DateCreate;
            element.DateImplement = model.DateImplement;
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(OrderBindingModel model)
        {
            GarmentFactoryDatabase context = new GarmentFactoryDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            GarmentFactoryDatabase context = new GarmentFactoryDatabase();
            Garment element = context.Garments.FirstOrDefault(rec => rec.Id == model.GarmentId);
            if (element != null)
            {
                if (element.Orders == null)
                {
                    element.Orders = new List<Order>();
                }
                element.Orders.Add(order);
                context.Garments.Update(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
            return order;
        }

        private static OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                GarmentId = order.GarmentId,
                GarmentName = order.Garment.GarmentName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
