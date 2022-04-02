using System;
using System.Collections.Generic;
using System.Linq;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryFileImplement.Models;

namespace GarmentFactoryFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;
        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var warehouse = source.Warehouses
                .FirstOrDefault(rec => rec.Id == model.Id || rec.WarehouseName == model.WarehouseName);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .Select(CreateModel)
                .ToList();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Textiles.Max(rec => rec.Id) : 0;
            var element = new Warehouse
            {
                Id = maxId + 1,
                WarehouseTextiles = new Dictionary<int, int>()
            };
            source.Warehouses.Add(CreateModel(model, element));
        }

        public bool TakeTextileFromWarehouse(Dictionary<int, (string, int)> textiles, int orderCount)
        {
            foreach (var textile in textiles)
            {
                int count = source.Warehouses
                    .Where(rec => rec.WarehouseTextiles.ContainsKey(textile.Key)).Sum(rec => rec.WarehouseTextiles[textile.Key]);
                if (count < textile.Value.Item2 * orderCount)
                {
                    return false;
                }
            }
            foreach (var textile in textiles)
            {
                int reqCount = textile.Value.Item2 * orderCount;
                foreach (var warehouse in source.Warehouses)
                {
                    var warehouseCond = warehouse.WarehouseTextiles;
                    if (!warehouseCond.ContainsKey(textile.Key))
                    {
                        continue;
                    }
                    if (warehouseCond[textile.Key] > reqCount)
                    {
                        warehouseCond[textile.Key] -= reqCount;
                        break;
                    }
                    else if (warehouseCond[textile.Key] <= reqCount)
                    {
                        reqCount -= warehouseCond[textile.Key];
                        warehouseCond.Remove(textile.Key);
                    }
                    if (reqCount == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }

        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses
               .FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
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
                WarehouseTextiles = warehouse.WarehouseTextiles.ToDictionary(recGT => recGT.Key, recGT => (source.Textiles.FirstOrDefault(recC => recC.Id == recGT.Key)?.TextileName, recGT.Value))
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
            foreach (var textile in model.WarehouseTextiles)
            {
                if (warehouse.WarehouseTextiles.ContainsKey(textile.Key))
                {
                    warehouse.WarehouseTextiles[textile.Key] = model.WarehouseTextiles[textile.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseTextiles.Add(textile.Key, model.WarehouseTextiles[textile.Key].Item2);
                }
            }
            return warehouse;
        }
    }
}
