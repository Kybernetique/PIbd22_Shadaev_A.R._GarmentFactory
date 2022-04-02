using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryListImplement.Models;

namespace GarmentFactoryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Textile> Textiles { get; set; }

        public List<Order> Orders { get; set; }

        public List<Garment> Garments { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        private DataListSingleton()
        {
            Textiles = new List<Textile>();
            Orders = new List<Order>();
            Garments = new List<Garment>();
            Warehouses = new List<Warehouse>();
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
