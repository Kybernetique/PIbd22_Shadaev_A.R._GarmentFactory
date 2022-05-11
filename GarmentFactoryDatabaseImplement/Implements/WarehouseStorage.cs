using System;
using System.Collections.Generic;
using System.Linq;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using Microsoft.EntityFrameworkCore;
using GarmentFactoryDatabaseImplement.Models;

namespace GarmentFactoryDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public void Delete(WarehouseBindingModel model)
        {
            var context = new GarmentFactoryDatabase();
            var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            context.Warehouses.Remove(warehouse);
            context.SaveChanges();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var context = new GarmentFactoryDatabase();
            var warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseTextiles)
                    .ThenInclude(rec => rec.Textile)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var context = new GarmentFactoryDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseTextiles)
                .ThenInclude(rec => rec.Textile)
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            var context = new GarmentFactoryDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseTextiles)
                .ThenInclude(rec => rec.Textile)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(WarehouseBindingModel model)
        {
            var context = new GarmentFactoryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                CreateModel(model, new Warehouse(), context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool TakeTextileFromWarehouse(Dictionary<int, (string, int)> textiles, int orderCount)
        {
            var context = new GarmentFactoryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var warehouseTextile in textiles)
                {
                    int count = warehouseTextile.Value.Item2 * orderCount;
                    IEnumerable<WarehouseTextile> warehouseTextiles = context.WarehouseTextiles
                        .Where(warehouse => warehouse.TextileId == warehouseTextile.Key);
                    foreach (var textile in warehouseTextiles)
                    {
                        if (textile.Count <= count)
                        {
                            count -= textile.Count;
                            context.WarehouseTextiles.Remove(textile);
                            context.SaveChanges();
                        }
                        else
                        {
                            textile.Count -= count;
                            context.SaveChanges();
                            count = 0;
                        }
                        if (count == 0)
                        {
                            break;
                        }
                    }
                    if (count != 0)
                    {
                        throw new Exception("Недостаточно тканей для передачи заказа в работу");
                    }
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public void Update(WarehouseBindingModel model)
        {
            var context = new GarmentFactoryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (warehouse == null)
                {
                    throw new Exception("Склад не найден");
                }

                CreateModel(model, warehouse, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, GarmentFactoryDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsibleFullName = model.ResponsibleFullName;

            if (warehouse.Id == 0)
            {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var WarehouseTextiles = context.WarehouseTextiles
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseTextiles.RemoveRange(WarehouseTextiles
                    .Where(rec => !model.WarehouseTextiles.ContainsKey(rec.TextileId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateTextile in WarehouseTextiles)
                {
                    updateTextile.Count = model.WarehouseTextiles[updateTextile.TextileId].Item2;
                    model.WarehouseTextiles.Remove(updateTextile.TextileId);
                }
                context.SaveChanges();
            }


            foreach (var WarehouseTextile in model.WarehouseTextiles)
            {
                context.WarehouseTextiles.Add(new WarehouseTextile
                {
                    WarehouseId = warehouse.Id,
                    TextileId = WarehouseTextile.Key,
                    Count = WarehouseTextile.Value.Item2
                });
                context.SaveChanges();
            }

            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsibleFullName = warehouse.ResponsibleFullName,
                CreateDate = warehouse.DateCreate,
                WarehouseTextiles = warehouse.WarehouseTextiles
                        .ToDictionary(recWarehouseTextiles => recWarehouseTextiles.TextileId,
                         recWarehouseTextiles => (recWarehouseTextiles.Textile?.TextileName,
                         recWarehouseTextiles.Count))
            };
        }
    }
}


