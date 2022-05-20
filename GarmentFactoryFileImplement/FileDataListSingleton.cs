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

        private readonly string ClientFileName = "C:\\Users\\Tony\\Desktop\\Client.xml";

        private readonly string ImplementerFileName = "Implementer.xml";

        private readonly string MessageFileName = "Message.xml";

        public List<Textile> Textiles { get; set; }

        public List<Order> Orders { get; set; }

        public List<Garment> Garments { get; set; }

        public List<Client> Clients { get; set; }

        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> Messages { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        private FileDataListSingleton()
        {
            Textiles = LoadTextiles();
            Orders = LoadOrders();
            Garments = LoadGarments();
            Warehouses = LoadWarehouses();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            Messages = LoadMessages();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        public void SaveData()
        {
            SaveTextiles();
            SaveOrders();
            SaveGarments();
            SaveClients();
            SaveWarehouses();
            SaveImplementers();
            SaveMessages();
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

        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value,
                    });
                }
            }
            return list;
        }

        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Attribute("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Attribute("PauseTime").Value),
                    });
                }
            }
            return list;
        }

        private List<MessageInfo> LoadMessages()
        {

            var list = new List<MessageInfo>();
            if (File.Exists(MessageFileName))
            {
                var xDocument = XDocument.Load(MessageFileName);
                var xElements = xDocument.Root.Elements("Message").ToList();
                int? clientId;
                foreach (var elem in xElements)
                {
                    clientId = null;
                    if (elem.Element("ClientId").Value != "")
                    {
                        clientId = Convert.ToInt32(elem.Element("ClientId").Value);
                    }
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = clientId,
                        Body = elem.Element("Body").Value,
                        SenderName = elem.Element("SenderName").Value,
                        Subject = elem.Element("Subject").Value,
                        DateDelivery = DateTime.Parse(elem.Element("DateDelivery").Value),
                        Viewed = Convert.ToBoolean(elem.Element("Viewed").Value),
                        ReplyText = elem.Element("ReplyText").Value
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
                var xElement = new XElement("Orders");
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
                    var texElement = new XElement("GarmentTextiles");
                    foreach (var textile in garment.GarmentTextiles)
                    {
                        texElement.Add(new XElement("GarmentTextile",
                        new XElement("Key", textile.Key),
                        new XElement("Value", textile.Value)));
                    }
                    xElement.Add(new XElement("Garment",
                     new XAttribute("Id", garment.Id),
                     new XElement("GarmentName", garment.GarmentName),
                     new XElement("Price", garment.Price),
                     texElement));
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

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);

            }
        }

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }

        private void SaveMessages()
        {
            if (Messages != null)
            {
                var xElement = new XElement("Messages");
                foreach (var message in Messages)
                {
                    xElement.Add(new XElement("Message",
                        new XAttribute("MessageId", message.MessageId),
                        new XElement("ClientId", message.ClientId),
                        new XElement("SenderName", message.SenderName),
                        new XElement("Subject", message.Subject),
                        new XElement("Body", message.Body),
                        new XElement("DateDelivery", message.DateDelivery),
                        new XElement("Viewed", message.Viewed),
                        new XElement("ReplyText", message.ReplyText)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
    }

}
