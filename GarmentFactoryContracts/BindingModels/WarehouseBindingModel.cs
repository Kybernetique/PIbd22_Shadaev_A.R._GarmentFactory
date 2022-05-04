using System;
using System.Collections.Generic;

namespace GarmentFactoryContracts.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }

        public string WarehouseName { get; set; }

        public string ResponsibleFullName { get; set; }

        public DateTime CreateDate { get; set; }

        public Dictionary<int, (string, int)> WarehouseTextiles { get; set; }
    }
}
