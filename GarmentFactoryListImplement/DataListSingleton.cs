using System;
using System.Collections.Generic;
using System.Text;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
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

        private DataListSingleton()
        {
            Textiles = new List<Textile>();
            Orders = new List<Order>();
            Garments = new List<Garment>();
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
