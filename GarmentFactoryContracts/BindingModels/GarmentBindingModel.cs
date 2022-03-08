using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.BindingModels
{
    // Швейное изделие, изготавливаемое на фабрике
    public class GarmentBindingModel
    {
        public int? Id { get; set; }

        public string GarmentName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> GarmentTextiles { get; set; }
    }
}
