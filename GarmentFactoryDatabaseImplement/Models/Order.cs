using System;
using System;
using System.ComponentModel.DataAnnotations;
using GarmentFactoryContracts.Enums;

namespace GarmentFactoryDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int GarmentId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }

        public virtual Garment Garment { get; set; }
    }
}
