using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.Enums;

namespace GarmentFactoryListImplement.Models
{
    // Заказ
    public class Order
    {
        public int Id { get; set; }

        public int GarmentId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

    }
}
