using GarmentFactoryContracts.Attributes;
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
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [Column(title: "Название швейного изделия", width: 150)]
        public string GarmentName { get; set; }

        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        [Column(title: "Ткани", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> GarmentTextiles { get; set; }

        public string GetTextiles()
        {
            string stringTextiles = string.Empty;
            if (GarmentTextiles != null)
            {
                foreach (var textile in GarmentTextiles)
                {
                    stringTextiles += textile.Key + ") " + textile.Value.Item1 + ": " + textile.Value.Item2 + ", ";
                }
            }
            return stringTextiles;
        }
    }
}
