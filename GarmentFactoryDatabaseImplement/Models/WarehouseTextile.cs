using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryDatabaseImplement.Models
{
    public class WarehouseTextile
    {
        public int Id { get; set; }

        public int TextileId { get; set; }

        public int WarehouseId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Textile Textile { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
