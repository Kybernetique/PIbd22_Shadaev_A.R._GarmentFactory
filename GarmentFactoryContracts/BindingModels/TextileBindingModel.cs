using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.BindingModels
{
    // Ткань, требуемая для изготовления швейного изделия
    public class TextileBindingModel
    {
        public int? Id { get; set; }

        public string TextileName { get; set; }
    }
}
