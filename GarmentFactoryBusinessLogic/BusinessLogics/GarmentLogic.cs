using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryBusinessLogic.BusinessLogics
{
    public class GarmentLogic : IGarmentLogic
    {
        private readonly IGarmentStorage _garmentStorage;

        public GarmentLogic(IGarmentStorage garmentStorage)
        {
            _garmentStorage = garmentStorage;
        }

        public void CreateOrUpdate(GarmentBindingModel model)
        {
            var element = _garmentStorage.GetElement(new GarmentBindingModel
            {
                GarmentName = model.GarmentName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть швейное изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                _garmentStorage.Update(model);
            }
            else
            {
                _garmentStorage.Insert(model);
            }
        }

        public void Delete(GarmentBindingModel model)
        {
            var element = _garmentStorage.GetElement(new GarmentBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _garmentStorage.Delete(model);
        }

        public List<GarmentViewModel> Read(GarmentBindingModel model)
        {
            if (model == null)
            {
                return _garmentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GarmentViewModel> { _garmentStorage.GetElement(model) };
            }
            return _garmentStorage.GetFilteredList(model);
        }
    }
}
