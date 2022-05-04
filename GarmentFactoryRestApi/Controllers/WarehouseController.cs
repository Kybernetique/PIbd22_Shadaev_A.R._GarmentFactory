using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseLogic warehouseLogic;

        private readonly ITextileLogic textileLogic;

        public WarehouseController(IWarehouseLogic warehouseLogic, ITextileLogic textileLogic)
        {
            this.warehouseLogic = warehouseLogic;
            this.textileLogic = textileLogic;
        }
        [HttpGet]
        public List<WarehouseViewModel> GetWarehouseList() => warehouseLogic.Read(null)?.ToList();
        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId) => warehouseLogic.Read(new WarehouseBindingModel { Id = warehouseId })?[0];
        [HttpGet]
        public List<TextileViewModel> GetTextilesList() => textileLogic.Read(null)?.ToList();
        [HttpPost]
        public void CreateUpdateWarehouse(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);
        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => warehouseLogic.Delete(model);
        [HttpPost]
        public void AddTextileWarehouse(WarehouseTextilesBindingModel model) =>
            warehouseLogic.AddTextile(new WarehouseBindingModel { Id = model.WarehouseId }, model.TextileId, model.Count);
    }
}