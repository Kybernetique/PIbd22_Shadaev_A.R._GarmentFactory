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
    public class TextileLogic : ITextileLogic
    {
        private readonly ITextileStorage _textileStorage;

        public TextileLogic(ITextileStorage textileStorage)
        {
            _textileStorage = textileStorage;
        }

        public void CreateOrUpdate(TextileBindingModel model)
        {
            var element = _textileStorage.GetElement(new TextileBindingModel
            {
                TextileName = model.TextileName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть ткань с таким названием");
            }
            if (model.Id.HasValue)
            {
                _textileStorage.Update(model);
            }
            else
            {
                _textileStorage.Insert(model);
            }
        }

        public void Delete(TextileBindingModel model)
        {
            var element = _textileStorage.GetElement(new TextileBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _textileStorage.Delete(model);
        }

        public List<TextileViewModel> Read(TextileBindingModel model)
        {
            if (model == null)
            {
                return _textileStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TextileViewModel> { _textileStorage.GetElement(model) };
            }
            return _textileStorage.GetFilteredList(model);
        }
    }
}
