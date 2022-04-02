using System;
using System.Collections.Generic;
using System.Linq;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryListImplement.Models;

namespace GarmentFactoryListImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly DataListSingleton source;

        public WarehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id ||
                    warehouse.WarehouseName == model.WarehouseName)
                {
                    return CreateModel(warehouse);
                }
            }
            return null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.WarehouseName.Contains(model.WarehouseName))
                {
                    result.Add(CreateModel(warehouse));
                }
            }
            return result;
        }

        public List<WarehouseViewModel> GetFullList()
        {
            var result = new List<WarehouseViewModel>();
            foreach (var textile in source.Warehouses)
            {
                result.Add(CreateModel(textile));
            }
            return result;
        }

        public void Insert(WarehouseBindingModel model)
        {
            var tempWarehouse = new Warehouse { Id = 1, WarehouseTextiles = new Dictionary<int, int>() };
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = warehouse.Id + 1;
                }
            }
            source.Warehouses.Add(CreateModel(model, tempWarehouse));
        }

        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = null;
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id)
                {
                    tempWarehouse = warehouse;
                }
            }
            if (tempWarehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempWarehouse);
        }
        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            var warehouseTextiles = new Dictionary<int, (string, int)>();
            foreach (var warehouseTextile in warehouse.WarehouseTextiles)
            {
                string textileName = string.Empty;
                foreach (var textile in source.Textiles)
                {
                    if (warehouseTextile.Key == textile.Id)
                    {
                        textileName = textile.TextileName;
                        break;
                    }
                }
                warehouseTextiles.Add(warehouseTextile.Key, (textileName, warehouseTextile.Value));
            }
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsibleFullName = warehouse.ResponsibleFullName,
                CreateDate = warehouse.CreateDate,
                WarehouseTextiles = warehouseTextiles
            };
        }

        private Warehouse CreateModel(WarehouseBindingModel model,
            Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsibleFullName = model.ResponsibleFullName;
            warehouse.CreateDate = model.CreateDate;
            foreach (var key in warehouse.WarehouseTextiles.Keys.ToList())
            {
                if (!model.WarehouseTextiles.ContainsKey(key))
                {
                    warehouse.WarehouseTextiles.Remove(key);
                }
            }
            foreach (var component in model.WarehouseTextiles)
            {
                if (warehouse.WarehouseTextiles.ContainsKey(component.Key))
                {
                    warehouse.WarehouseTextiles[component.Key] = model.WarehouseTextiles[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseTextiles.Add(component.Key, model.WarehouseTextiles[component.Key].Item2);
                }
            }
            return warehouse;
        }
    }
}
