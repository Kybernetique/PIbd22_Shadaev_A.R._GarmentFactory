using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryListImplement.Models
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
