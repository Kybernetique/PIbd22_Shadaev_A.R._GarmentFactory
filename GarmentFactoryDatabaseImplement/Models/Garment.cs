using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarmentFactoryDatabaseImplement.Models
{
    public class Garment
    {
        public int Id { get; set; }

        [Required]
        public string GarmentName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("GarmentId")]
        public virtual List<GarmentTextile> GarmentTextiles { get; set; }

        [ForeignKey("GarmentId")]
        public virtual List<Order> Orders { get; set; }
    }
}
