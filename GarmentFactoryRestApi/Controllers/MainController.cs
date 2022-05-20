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

        private readonly IMessageInfoLogic _message;

        private readonly int mailsOnPage = 2;

        public MainController(IOrderLogic order, IGarmentLogic garment, IMessageInfoLogic message)
        {
            _order = order;
            _garment = garment;
            _message = message;
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

        [HttpGet]
        public (List<MessageInfoViewModel>, bool) GetMessages(int clientId, int page)
        {
            var list = _message.Read(new MessageInfoBindingModel
            {
                ClientId = clientId,
                ToSkip = (page - 1) * mailsOnPage,
                ToTake = mailsOnPage + 1
            })
                .ToList();
            var hasNext = !(list.Count() <= mailsOnPage);
            return (list.Take(mailsOnPage).ToList(), hasNext);
        }

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
        _order.CreateOrder(model);
    }
}
