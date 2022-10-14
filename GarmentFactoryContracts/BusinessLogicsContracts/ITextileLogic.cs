using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryContracts.BusinessLogicsContracts
{
    public interface ITextileLogic
    {
        List<TextileViewModel> Read(TextileBindingModel model);

        void CreateOrUpdate(TextileBindingModel model);

        void Delete(TextileBindingModel model);
    }
}
