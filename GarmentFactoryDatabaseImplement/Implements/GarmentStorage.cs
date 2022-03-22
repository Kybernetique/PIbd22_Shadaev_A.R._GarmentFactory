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
    public class GarmentStorage : IGarmentStorage
    {
        public List<GarmentViewModel> GetFullList()
        {
            using var context = new GarmentFactoryDatabase();
            return context.Garments
            .Include(rec => rec.GarmentTextiles)
            .ThenInclude(rec => rec.Textile)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<GarmentViewModel> GetFilteredList(GarmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            return context.Garments
            .Include(rec => rec.GarmentTextiles)
            .ThenInclude(rec => rec.Textile)
            .Where(rec => rec.GarmentName.Contains(model.GarmentName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public GarmentViewModel GetElement(GarmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            var garment = context.Garments
            .Include(rec => rec.GarmentTextiles)
            .ThenInclude(rec => rec.Textile)
            .FirstOrDefault(rec => rec.GarmentName == model.GarmentName ||
            rec.Id == model.Id);
            return garment != null ? CreateModel(garment) :
           null;
        }

        public void Insert(GarmentBindingModel model)
        {
            var context = new GarmentFactoryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                Garment g = new Garment
                {
                    GarmentName = model.GarmentName,
                    Price = model.Price
                };
                context.Garments.Add(g);
                context.SaveChanges();
                CreateModel(model, g, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(GarmentBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Garments.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(GarmentBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            Garment element = context.Garments.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Garments.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Garment CreateModel(GarmentBindingModel model, Garment garment,
        GarmentFactoryDatabase context)
        {
            garment.GarmentName = model.GarmentName;
            garment.Price = model.Price;
            if (model.Id.HasValue)
            {
                var garmentTextiles = context.GarmentTextiles.Where(rec =>
                rec.GarmentId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.GarmentTextiles.RemoveRange(garmentTextiles.Where(rec =>
                !model.GarmentTextiles.ContainsKey(rec.TextileId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateTextile in garmentTextiles)
                {
                    updateTextile.Count =
                    model.GarmentTextiles[updateTextile.TextileId].Item2;
                    model.GarmentTextiles.Remove(updateTextile.TextileId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var gt in model.GarmentTextiles)
            {
                context.GarmentTextiles.Add(new GarmentTextile
                {
                    GarmentId = garment.Id,
                    TextileId = gt.Key,
                    Count = gt.Value.Item2
                });
                context.SaveChanges();
            }
            return garment;
        }

        private static GarmentViewModel CreateModel(Garment garment)
        {
            return new GarmentViewModel
            {
                Id = garment.Id,
                GarmentName = garment.GarmentName,
                Price = garment.Price,
                GarmentTextiles = garment.GarmentTextiles
            .ToDictionary(recGT => recGT.TextileId,
            recGT => (recGT.Textile?.TextileName, recGT.Count))
            };
        }
    }
}
