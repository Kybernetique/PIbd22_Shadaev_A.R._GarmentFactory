using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryDatabaseImplement.Models;

namespace GarmentFactoryDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public void Delete(ClientBindingModel model)
        {
            using (var context = new GarmentFactoryDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new GarmentFactoryDatabase())
            {
                var client = context.Clients.Include(x => x.Orders)
                .FirstOrDefault(rec => rec.Email == model.Login || rec.Id == model.Id);
                return client != null ? CreateModel(client) : null;
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new GarmentFactoryDatabase())
            {
                return context.Clients.Include(x => x.Orders)
                .Where(rec => rec.Email == model.Login && rec.Password == model.Password)
                .Select(CreateModel)
                .ToList();
            }
        }

        public List<ClientViewModel> GetFullList()
        {
            using (var context = new GarmentFactoryDatabase())
            {
                return context.Clients.Select(CreateModel).ToList();
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (var context = new GarmentFactoryDatabase())
            {
                context.Clients.Add(CreateModel(model, new Client()));
                context.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            using (var context = new GarmentFactoryDatabase())
            {
                var element = context.Clients.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Login;
            client.Password = model.Password;
            return client;
        }
        private ClientViewModel CreateModel(Client model)
        {
            return new ClientViewModel
            {
                Id = model.Id,
                ClientFIO = model.ClientFIO,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}
