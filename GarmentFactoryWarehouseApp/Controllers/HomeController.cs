using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryWarehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GarmentFactoryWarehouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            if (Program.Authorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIClient.GetRequest<List<WarehouseViewModel>>($"api/Warehouse/GetWarehouseList"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (configuration["password"] != password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.Authorized = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите пароль");
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (Program.Authorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }
        [HttpPost]
        public void Create(string warehouseName, string responsible)
        {
            if (String.IsNullOrEmpty(warehouseName) || String.IsNullOrEmpty(responsible))
            {
                return;
            }
            APIClient.PostRequest("api/Warehouse/CreateUpdateWarehouse", new WarehouseBindingModel
            {
                WarehouseName = warehouseName,
                ResponsibleFullName = responsible,
                CreateDate = DateTime.Now,
                WarehouseTextiles = new Dictionary<int, (string, int)>()
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Adding()
        {
            if (Program.Authorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Warehouses = APIClient.GetRequest<List<WarehouseViewModel>>("api/Warehouse/GetWarehouseList");
            ViewBag.Textiles = APIClient.GetRequest<List<TextileViewModel>>("api/Warehouse/GetTextilesList");
            return View();
        }
        [HttpPost]
        public void Adding(int warehouse, int textile, int count)
        {
            APIClient.PostRequest("api/Warehouse/AddTextileWarehouse", new WarehouseTextilesBindingModel
            {
                WarehouseId = warehouse,
                TextileId = textile,
                Count = count
            });
            Response.Redirect("Adding");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Authorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Warehouses = APIClient.GetRequest<List<WarehouseViewModel>>("api/Warehouse/GetWarehouseList");
            return View();
        }
        [HttpPost]
        public void Delete(int warehouse)
        {
            APIClient.PostRequest("api/Warehouse/DeleteWarehouse", new WarehouseBindingModel
            {
                Id = warehouse
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Editing(int warehouseId)
        {
            if (Program.Authorized == false)
            {
                return Redirect("~/Home/Enter");
            }
            WarehouseViewModel warehouse = APIClient.GetRequest<WarehouseViewModel>($"api/Warehouse/GetWarehouse?warehouseId={warehouseId}");
            ViewBag.WarehouseName = warehouse.WarehouseName;
            ViewBag.ResponsibleFullName = warehouse.ResponsibleFullName;
            ViewBag.WarehouseTextiles = warehouse.WarehouseTextiles;
            return View();
        }
        [HttpPost]
        public void Editing(int warehouseId, string warehouseName, string responsible)
        {
            if (String.IsNullOrEmpty(warehouseName) || String.IsNullOrEmpty(responsible))
            {
                return;
            }
            WarehouseViewModel warehouse = APIClient.GetRequest<WarehouseViewModel>($"api/Warehouse/GetWarehouse?warehouseId={warehouseId}");
            APIClient.PostRequest("api/Warehouse/CreateUpdateWarehouse", new WarehouseBindingModel
            {
                Id = warehouseId,
                WarehouseName = warehouseName,
                ResponsibleFullName = responsible,
                WarehouseTextiles = warehouse.WarehouseTextiles,
                CreateDate = DateTime.Now
            });
            Response.Redirect("Index");
        }
    }
}
