using System;
using System.Collections.Generic;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryBusinessLogic.BusinessLogics
{
    public class WarehouseLogic : IWarehouseLogic
    {
        public IWarehouseStorage _warehouseStorage;

        public ITextileStorage _textileStorage;

        public WarehouseLogic(IWarehouseStorage warehouseStorage, ITextileStorage textileStorage)
        {
            _warehouseStorage = warehouseStorage;
            _textileStorage = textileStorage;
        }

        public void AddTextile(WarehouseBindingModel model, int componentId, int count)
        {
            var warehouse = _warehouseStorage.GetElement(new WarehouseBindingModel { Id = model.Id });
            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }
            var textile = _textileStorage.GetElement(new TextileBindingModel { Id = componentId });
            if (textile == null)
            {
                throw new Exception("Ткань не найдена");
            }
            if (warehouse.WarehouseTextiles.ContainsKey(componentId))
            {
                warehouse.WarehouseTextiles[componentId] = (textile.TextileName, warehouse.WarehouseTextiles[componentId].Item2 + count);
            }
            else
            {
                warehouse.WarehouseTextiles.Add(componentId, (textile.TextileName, count));
            }
            _warehouseStorage.Update(new WarehouseBindingModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsibleFullName = warehouse.ResponsibleFullName,
                CreateDate = warehouse.CreateDate,
                WarehouseTextiles = warehouse.WarehouseTextiles
            });
        }

        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                WarehouseName = model.WarehouseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _warehouseStorage.Update(model);
            }
            else
            {
                _warehouseStorage.Insert(model);
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _warehouseStorage.Delete(model);
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return _warehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WarehouseViewModel> { _warehouseStorage.GetElement(model) };
            }
            return _warehouseStorage.GetFilteredList(model);
        }
    }
}
