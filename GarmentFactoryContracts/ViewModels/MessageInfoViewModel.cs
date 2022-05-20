using System;
using System.ComponentModel;


namespace GarmentFactoryContracts.ViewModels
{
    public class MessageInfoViewModel
    {
        public string MessageId { get; set; }

        [DisplayName("Отправитель")]
        public string SenderName { get; set; }

        [DisplayName("Дата")]
        public DateTime DateDelivery { get; set; }

        [DisplayName("Заголовок")]
        public string Subject { get; set; }

        [DisplayName("Текст")]
        public string Body { get; set; }

        [DisplayName("Прочтено")]
        public bool Viewed { get; set; }

        [DisplayName("Ответ")]
        public string ReplyText { get; set; }
    }
}
