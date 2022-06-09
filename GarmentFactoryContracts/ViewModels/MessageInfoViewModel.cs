using GarmentFactoryContracts.Attributes;
using System;
using System.ComponentModel;


namespace GarmentFactoryContracts.ViewModels
{
    public class MessageInfoViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public string MessageId { get; set; }

        [Column(title: "Отправитель", width: 150)]
        public string SenderName { get; set; }

        [Column(title: "Дата письма", width: 100)]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 100)]
        public string Subject { get; set; }

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.AllCells)]

        public string Body { get; set; }
        [Column(title: "Статус", width: 50)]

        public bool Viewed { get; set; }

        [Column(title: "Ответ", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ReplyText
        {
            get; set;
        }
    }
}
