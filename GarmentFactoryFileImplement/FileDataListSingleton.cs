using System;
using System.Collections.Generic;
using System.Linq;
using GarmentFactoryContracts.Enums;
using GarmentFactoryFileImplement.Models;
using System.IO;
using System.Xml.Linq;

namespace GarmentFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string TextileFileName = "C:\\Users\\Tony\\Desktop\\Textile.xml";

        private readonly string OrderFileName = "C:\\Users\\Tony\\Desktop\\Order.xml";

        private readonly string GarmentFileName = "C:\\Users\\Tony\\Desktop\\Garment.xml";

        private readonly string WarehouseFileName = "C:\\Users\\Tony\\Desktop\\Warehouse.xml";

        public List<Textile> Textiles { get; set; }

        public List<Order> Orders { get; set; }

        public List<Garment> Garments { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        private FileDataListSingleton()
        {
            Textiles = LoadTextiles();
            Orders = LoadOrders();
            Garments = LoadGarments();
            Warehouses = LoadWarehouses();
        }

        public void SaveData()
        {
            SaveTextiles();
            SaveOrders();
            SaveGarments();
            SaveWarehouses();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        private List<Textile> LoadTextiles()
        {
            var list = new List<Textile>();
            if (File.Exists(TextileFileName))
            {
                var xDocument = XDocument.Load(TextileFileName);
                var xElements = xDocument.Root.Elements("Textile").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Textile
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TextileName = elem.Element("TextileName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GarmentId = Convert.ToInt32(elem.Element("GarmentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                        Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                };
            }
            return list;
        }
        private List<Garment> LoadGarments()
        {
            var list = new List<Garment>();
            if (File.Exists(GarmentFileName))
            {
                var xDocument = XDocument.Load(GarmentFileName);
                var xElements = xDocument.Root.Elements("Garment").ToList();
                foreach (var elem in xElements)
                {
                    var garmentTextiles = new Dictionary<int, int>();
                    foreach (var textile in
                   elem.Element("GarmentTextiles").Elements("GarmentTextile").ToList())
                    {
                        garmentTextiles.Add(Convert.ToInt32(textile.Element("Key").Value),
                       Convert.ToInt32(textile.Element("Value").Value));
                    }
                    list.Add(new Garment
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GarmentName = elem.Element("GarmentName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        GarmentTextiles = garmentTextiles
                    });
                }
            }
            return list;
        }
        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();
            if (File.Exists(WarehouseFileName))
            {
                var xDocument = XDocument.Load(WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();
                foreach (var elem in xElements)
                {
                    var garmentTextile = new Dictionary<int, int>();
                    foreach (var textile in elem.Element("WarehouseTextiles").Elements("WarehouseTextile").ToList())
                    {
                        garmentTextile.Add(Convert.ToInt32(textile.Element("Key").Value),
                       Convert.ToInt32(textile.Element("Value").Value));
                    }
                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value,
                        ResponsibleFullName = elem.Element("ResponsibleFullName").Value,
                        CreateDate = Convert.ToDateTime(elem.Element("CreateDate").Value),
                        WarehouseTextiles = garmentTextile
                    });
                }
            }
            return list;
        }
        private void SaveTextiles()
        {
            if (Textiles != null)
            {
                var xElement = new XElement("Textiles");
                foreach (var textile in Textiles)
                {
                    xElement.Add(new XElement("Textile",
                    new XAttribute("Id", textile.Id),
                    new XElement("TextileName", textile.TextileName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(TextileFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orderss");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("GarmentId", order.GarmentId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveGarments()
        {
            if (Garments != null)
            {
                var xElement = new XElement("Garments");
                foreach (var garment in Garments)
                {
                    var compElement = new XElement("GarmentTextiles");
                    foreach (var textile in garment.GarmentTextiles)
                    {
                        compElement.Add(new XElement("GarmentTextile",
                        new XElement("Key", textile.Key),
                        new XElement("Value", textile.Value)));
                    }
                    xElement.Add(new XElement("Garment",
                     new XAttribute("Id", garment.Id),
                     new XElement("GarmentName", garment.GarmentName),
                     new XElement("Price", garment.Price),
                     compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(GarmentFileName);
            }
        }
        private void SaveWarehouses()
        {
            if (Warehouses != null)
            {
                var xElement = new XElement("Warehouses");
                foreach (var warehouse in Warehouses)
                {
                    var warehouseElement = new XElement("WarehouseTextiles");
                    foreach (var textile in warehouse.WarehouseTextiles)
                    {
                        warehouseElement.Add(new XElement("WarehouseTextile",
                            new XElement("Key", textile.Key),
                            new XElement("Value", textile.Value)));
                    }
                    xElement.Add(new XElement("Warehouse",
                        new XAttribute("Id", warehouse.Id),
                        new XElement("WarehouseName", warehouse.WarehouseName),
                        new XElement("CreateDate", warehouse.CreateDate),
                        new XElement("ResponsibleFullName", warehouse.ResponsibleFullName),
                        warehouseElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }
    }

}
