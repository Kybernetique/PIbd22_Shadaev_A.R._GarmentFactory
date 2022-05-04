using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GarmentFactoryContracts.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string ResponsibleFullName { get; set; }

        [DisplayName("Дата создания")]
        public DateTime CreateDate { get; set; }

        public Dictionary<int, (string, int)> WarehouseTextiles { get; set; }
    }
}
