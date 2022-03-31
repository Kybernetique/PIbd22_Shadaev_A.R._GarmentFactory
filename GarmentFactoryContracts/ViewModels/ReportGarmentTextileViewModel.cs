using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.ViewModels
{
    public class ReportGarmentTextileViewModel
    {
        public string TextileName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Garments { get; set; }
    }
}
