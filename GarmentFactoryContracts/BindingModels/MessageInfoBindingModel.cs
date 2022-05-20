using System;
using System.Runtime.Serialization;

namespace GarmentFactoryContracts.BindingModels
{
    public class MessageInfoBindingModel
    {
        public int? ClientId { get; set; }
        
        public string MessageId { get; set; }

        public string FromMailAddress { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool Viewed { get; set; }

        public string ReplyText { get; set; }

        public DateTime DateDelivery { get; set; }

        [DataMember]
        public int? ToSkip { get; set; }

        [DataMember]
        public int? ToTake { get; set; }
    }
}
