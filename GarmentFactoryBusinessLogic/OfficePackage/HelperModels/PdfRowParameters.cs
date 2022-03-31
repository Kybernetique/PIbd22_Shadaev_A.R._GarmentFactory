using GarmentFactoryBusinessLogic.OfficePackage.HelperEnums;
using System.Collections.Generic;

namespace GarmentFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class PdfRowParameters
    {
        public List<string> Texts { get; set; }
        public string Style { get; set; }
        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}
