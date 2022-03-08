using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.ViewModels
{
    // Изделие, изготавливаемое в магазине
    public class GarmentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название швейного изделия")]
        public string GarmentName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> GarmentTextiles { get; set; }
    }
}
