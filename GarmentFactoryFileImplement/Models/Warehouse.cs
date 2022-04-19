using System;
using System.Collections.Generic;

namespace GarmentFactoryFileImplement.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        public string WarehouseName { get; set; }

        public string ResponsibleFullName { get; set; }

        public DateTime CreateDate { get; set; }

        public Dictionary<int, int> WarehouseTextiles { get; set; }
    }
}
