using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryContracts.StoragesContracts
{
    public interface ITextileStorage
    {
        List<TextileViewModel> GetFullList();

        List<TextileViewModel> GetFilteredList(TextileBindingModel model);

        TextileViewModel GetElement(TextileBindingModel model);

        void Insert(TextileBindingModel model);

        void Update(TextileBindingModel model);

        void Delete(TextileBindingModel model);

    }
}
