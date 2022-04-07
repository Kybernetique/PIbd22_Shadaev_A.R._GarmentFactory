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
    public class GarmentStorage : IGarmentStorage
    {
        private readonly DataListSingleton source;

        public GarmentStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        private static Garment CreateModel(GarmentBindingModel model, Garment
        garment)
        {
            garment.GarmentName = model.GarmentName;
            garment.Price = model.Price;
            // удаляем убранные
            foreach (var key in garment.GarmentTextiles.Keys.ToList())
            {
                if (!model.GarmentTextiles.ContainsKey(key))
                {
                    garment.GarmentTextiles.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var textile in model.GarmentTextiles)
            {
                if (garment.GarmentTextiles.ContainsKey(textile.Key))
                {
                    garment.GarmentTextiles[textile.Key] =
                    model.GarmentTextiles[textile.Key].Item2;
                }
                else
                {
                    garment.GarmentTextiles.Add(textile.Key,
                    model.GarmentTextiles[textile.Key].Item2);
                }
            }
            return garment;
        }

        private GarmentViewModel CreateModel(Garment garment)
        {
            // требуется дополнительно получить список тканей для швейного изделия с
            // названиями и их количество
            var garmentTextiles = new Dictionary<int, (string, int)>();
            foreach (var gt in garment.GarmentTextiles)
            {
                string textileName = string.Empty;
                foreach (var textile in source.Textiles)
                {
                    if (gt.Key == textile.Id)
                    {
                        textileName = textile.TextileName;
                        break;
                    }
                }
                garmentTextiles.Add(gt.Key, (textileName, gt.Value));
            }
            return new GarmentViewModel
            {
                Id = garment.Id,
                GarmentName = garment.GarmentName,
                Price = garment.Price,
                GarmentTextiles = garmentTextiles
            };
        }

        public void Delete(GarmentBindingModel model)
        {
            for (int i = 0; i < source.Garments.Count; ++i)
            {
                if (source.Garments[i].Id == model.Id)
                {
                    source.Garments.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");

        }

        public GarmentViewModel GetElement(GarmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var garment in source.Garments)
            {
                if (garment.Id == model.Id || garment.GarmentName ==
                model.GarmentName)
                {
                    return CreateModel(garment);
                }
            }
            return null;

        }

        public List<GarmentViewModel> GetFilteredList(GarmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<GarmentViewModel>();
            foreach (var garment in source.Garments)
            {
                if (garment.GarmentName.Contains(model.GarmentName))
                {
                    result.Add(CreateModel(garment));
                }
            }
            return result;
        }

        public List<GarmentViewModel> GetFullList()
        {
            var result = new List<GarmentViewModel>();

            foreach (var garment in source.Garments)
            {
                result.Add(CreateModel(garment));
            }
            return result;
        }

        public void Insert(GarmentBindingModel model)
        {
            var tempGarment = new Garment
            {
                Id = 1,
                GarmentTextiles = new
Dictionary<int, int>()
            };
            foreach (var garment in source.Garments)
            {
                if (garment.Id >= tempGarment.Id)
                {
                    tempGarment.Id = garment.Id + 1;
                }
            }
            source.Garments.Add(CreateModel(model, tempGarment));
        }

        public void Update(GarmentBindingModel model)
        {
            Garment tempGarment = null;
            foreach (var garment in source.Garments)
            {
                if (garment.Id == model.Id)
                {
                    tempGarment = garment;
                }
            }
            if (tempGarment == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempGarment);

        }
    }
}
