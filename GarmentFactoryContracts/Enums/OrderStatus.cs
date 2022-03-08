using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryContracts.Enums
{
    // Статус заказа
    public enum OrderStatus
    {
        Принят = 0,

        Выполняется = 1,

        Готов = 2,

        Выдан = 3
    }
}
