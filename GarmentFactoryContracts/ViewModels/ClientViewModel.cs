using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GarmentFactoryContracts.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
