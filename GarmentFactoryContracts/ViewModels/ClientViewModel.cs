using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GarmentFactoryContracts.Attributes;

namespace GarmentFactoryContracts.ViewModels
{
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "ФИО Клиента", width: 150)]
        public string ClientFIO { get; set; }

        [Column(title: "Почта", width: 100)]
        public string Email { get; set; }

        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}
