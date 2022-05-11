using GarmentFactoryContracts.Attributes;
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
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [Column(title: "Ткань", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TextileName { get; set; }

    }
}
