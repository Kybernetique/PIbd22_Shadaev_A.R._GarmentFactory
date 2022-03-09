using System.Collections.Generic;

namespace GarmentFactoryFileImplement.Models
{
    // Швейное изделие, изготавливаемое на фабрике
    public class Garment
    {
        public int Id { get; set; }

        public string GarmentName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> GarmentTextiles { get; set; }
    }
}
