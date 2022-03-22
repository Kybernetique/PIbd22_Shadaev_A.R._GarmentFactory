using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarmentFactoryDatabaseImplement.Implements
{
    public class TextileStorage : ITextileStorage
    {
        public List<TextileViewModel> GetFullList()
        {
            using var context = new GarmentFactoryDatabase();
            return context.Textiles
            .Select(rec => new TextileViewModel
            {
                Id = rec.Id,
                TextileName = rec.TextileName
            })
            .ToList();

        }

        public void Delete(TextileBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            Textile element = context.Textiles.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Textiles.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public TextileViewModel GetElement(TextileBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            var textile = context.Textiles
            .FirstOrDefault(rec => rec.TextileName == model.TextileName || rec.Id
            == model.Id);
            return textile != null ? CreateModel(textile) : null;
        }

        public List<TextileViewModel> GetFilteredList(TextileBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            return context.Textiles
            .Where(rec => rec.TextileName.Contains(model.TextileName))
           .Select(rec => new TextileViewModel
           {
               Id = rec.Id,
               TextileName = rec.TextileName
           })
            .ToList();

        }

        public void Insert(TextileBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            context.Textiles.Add(CreateModel(model, new Textile()));
            context.SaveChanges();
        }

        public void Update(TextileBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            var element = context.Textiles.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        private static Textile CreateModel(TextileBindingModel model, Textile
textile)
        {
            textile.TextileName = model.TextileName;
            return textile;
        }

        private static TextileViewModel CreateModel(Textile textile)
        {
            return new TextileViewModel
            {
                Id = textile.Id,
                TextileName = textile.TextileName
            };
        }
    }
}
