using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GarmentFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        
        private readonly IGarmentLogic _garment;
        public MainController(IOrderLogic order, IGarmentLogic garment)
        {
            _order = order;
            _garment = garment;
        }
        
        [HttpGet]
        public List<GarmentViewModel> GetGarmentList() => _garment.Read(null)?.ToList();
        
        [HttpGet]
        public GarmentViewModel GetGarment(int garmentId) => _garment.Read(new
        GarmentBindingModel
        { Id = garmentId })?[0];
        
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
        OrderBindingModel
        { ClientId = clientId });
        
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
        _order.CreateOrder(model);
    }
}
