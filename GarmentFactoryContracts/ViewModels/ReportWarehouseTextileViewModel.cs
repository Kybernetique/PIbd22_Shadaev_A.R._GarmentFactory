using System;
using System.Collections.Generic;

namespace GarmentFactoryContracts.ViewModels
{
    public class ReportWarehouseTextileViewModel
    {
        public string WarehouseName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Textiles { get; set; }
    }
}
