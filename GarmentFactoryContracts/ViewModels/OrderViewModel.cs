using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.Enums;

namespace GarmentFactoryContracts.ViewModels
{
    // Заказ
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int GarmentId { get; set; }

        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; }

        [DisplayName("Швейное изделие")]
        public string GarmentName { get; set; }

        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
