using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryListImplement.Models;

namespace GarmentFactoryListImplement.Implements
{

    public class TextileStorage : ITextileStorage
    {
        private readonly DataListSingleton source;

        public TextileStorage()
        {
            source = DataListSingleton.GetInstance();
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

        public void Delete(TextileBindingModel model)
        {
            for (int i = 0; i < source.Textiles.Count; ++i)
            {
                if (source.Textiles[i].Id == model.Id.Value)
                {
                    source.Textiles.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public TextileViewModel GetElement(TextileBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var textile in source.Textiles)
            {
                if (textile.Id == model.Id || textile.TextileName ==
               model.TextileName)
                {
                    return CreateModel(textile);
                }
            }
            return null;
        }

        public List<TextileViewModel> GetFilteredList(TextileBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<TextileViewModel>();
            foreach (var textile in source.Textiles)
            {
                if (textile.TextileName.Contains(model.TextileName))
                {
                    result.Add(CreateModel(textile));
                }
            }
            return result;
        }

        public List<TextileViewModel> GetFullList()
        {
            var result = new List<TextileViewModel>();

            foreach (var textile in source.Textiles)
            {
                result.Add(CreateModel(textile));
            }
            return result;

        }

        public void Insert(TextileBindingModel model)
        {
            var tempTextile = new Textile { Id = 1 };
            foreach (var textile in source.Textiles)
            {
                if (textile.Id >= tempTextile.Id)
                {
                    tempTextile.Id = textile.Id + 1;
                }
            }
            source.Textiles.Add(CreateModel(model, tempTextile));
        }

        public void Update(TextileBindingModel model)
        {
            Textile tempTextile = null;
            foreach (var textile in source.Textiles)
            {
                if (textile.Id == model.Id)
                {
                    tempTextile = textile;
                }
            }
            if (tempTextile == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempTextile);
        }
    }
}
