using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryBusinessLogic.BusinessLogics
{

    public class ClientLogic : IClientLogic
    {
        private readonly IClientStorage _clientStorage;

        private readonly int _passwordMaxLength = 50;

        private readonly int _passwordMinLength = 10;

        public ClientLogic(IClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel { Email = model.Email });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть клиент с таким логином");
            }
            if (!Regex.IsMatch(model.Email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                throw new Exception("В качестве логина почта указана должна быть");
            }
/*            if (model.Password.Length > _passwordMaxLength || model.Password.Length <
           _passwordMinLength || !Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"Пароль длиной от {_passwordMinLength} до { _passwordMaxLength } должен быть и из цифр, букв и небуквенных символов должен состоять");
            }
*/
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }

        public void Delete(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _clientStorage.Delete(model);
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue || !string.IsNullOrEmpty(model.Email))
            {
                return new List<ClientViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }
    }
}
