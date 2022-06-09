using GarmentFactoryContracts.Attributes;

namespace GarmentFactoryContracts.ViewModels
{
    // Ткань, требуемая для изготовления швейного изделия
    public class TextileViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Название ткани", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TextileName { get; set; }

    }
}
