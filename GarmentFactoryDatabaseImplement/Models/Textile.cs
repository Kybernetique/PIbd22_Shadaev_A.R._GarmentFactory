using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarmentFactoryDatabaseImplement.Models
{
    // Ткань, требуемая для изготовления швейного изделия
    public class Textile
    {
        public int Id { get; set; }
        
        [Required]
        public string TextileName { get; set; }
        
        [ForeignKey("TextileId")]
        public virtual List<GarmentTextile> GarmentTextiles{ get; set; }

        [ForeignKey("TextileId")]
        public virtual List<WarehouseTextile> WarehouseTextiles { get; set; }
    }
}
