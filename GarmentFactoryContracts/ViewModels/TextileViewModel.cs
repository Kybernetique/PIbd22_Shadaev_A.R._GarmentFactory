using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.ViewModels
{
    // Ткань, требуемая для изготовления швейного изделия
    public class TextileViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название ткани")]
        public string TextileName { get; set; }

    }
}
