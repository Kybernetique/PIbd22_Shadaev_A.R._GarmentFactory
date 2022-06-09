using GarmentFactoryContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GarmentFactoryContracts.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        [Column(title: "Название склада", width: 100)]
        public string WarehouseName { get; set; }
        [DisplayName("ФИО ответственного")]
        [Column(title: "ФИО ответственного", width: 50)]
        public string ResponsibleFullName { get; set; }
        [DisplayName("Дата создания")]
        [Column(title: "Дата создания", width: 100, dateFormat: "d")]
        public DateTime CreateDate { get; set; }
        public Dictionary<int, (string, int)> WarehouseTextiles { get; set; }
    }
}
