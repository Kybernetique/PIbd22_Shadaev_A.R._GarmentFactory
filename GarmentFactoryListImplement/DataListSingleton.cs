using System;
using System.Collections.Generic;
using System.Text;
using GarmentFactoryListImplement.Models;

namespace GarmentFactoryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Textile> Textiles { get; set; }

        public List<Order> Orders { get; set; }

        public List<Garment> Garments { get; set; }

        public List<Client> Clients { get; set; }

        public List<Implementer> Implementers { get; set; }

        private DataListSingleton()
        {
            Textiles = new List<Textile>();
            Orders = new List<Order>();
            Garments = new List<Garment>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}
