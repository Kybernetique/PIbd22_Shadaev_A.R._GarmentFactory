using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.BindingModels
{
    public class WarehouseTextilesBindingModel
    {
        public int WarehouseId { get; set; }

        public int TextileId { get; set; }

        public int Count { get; set; }
    }
}
