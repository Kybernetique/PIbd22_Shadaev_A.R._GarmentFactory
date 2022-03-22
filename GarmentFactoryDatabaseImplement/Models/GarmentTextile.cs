using System.ComponentModel.DataAnnotations;

namespace GarmentFactoryDatabaseImplement.Models
{
    // Сколько тканей, требуется при изготовлении швейного изделия
    public class GarmentTextile
    {
        public int Id { get; set; }

        public int GarmentId { get; set; }

        public int TextileId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Textile Textile { get; set; }

        public virtual Garment Garment { get; set; }
    }
}
