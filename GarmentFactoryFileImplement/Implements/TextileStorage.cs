using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarmentFactoryFileImplement.Implements
{
    public class TextileStorage : ITextileStorage
    {
        private readonly FileDataListSingleton source;

        public TextileStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<TextileViewModel> GetFullList()
        {
            return source.Textiles
                .Select(CreateModel)
                .ToList();
        }
        public List<TextileViewModel> GetFilteredList(TextileBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Textiles
                .Where(rec => rec.TextileName.Contains(model.TextileName))
                .Select(CreateModel)
                .ToList();
        }

        public TextileViewModel GetElement(TextileBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var textile = source.Textiles
                .FirstOrDefault(rec => rec.TextileName == model.TextileName || rec.Id == model.Id);
            return textile != null ? CreateModel(textile) : null;
        }

        public void Insert(TextileBindingModel model)
        {
            int maxId = source.Textiles.Count > 0 ? source.Textiles.Max(rec => rec.Id) : 0;
            var element = new Textile { Id = maxId + 1 };
            source.Textiles.Add(CreateModel(model, element));
        }

        public void Update(TextileBindingModel model)
        {
            var element = source.Textiles.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(TextileBindingModel model)
        {
            Textile element = source.Textiles.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Textiles.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Textile CreateModel(TextileBindingModel model, Textile textile)
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
