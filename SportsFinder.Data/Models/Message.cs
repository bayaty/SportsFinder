using System;
using System.Collections.Generic;
using System.Text;

namespace SportsFinder.Data.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageFromId { get; set; }
        public string MessageToId { get; set; }
        public string MessageContent { get; set; }
        public int MessageStatusId { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateReceived { get; set; }
        public virtual MessageStatus MessageStatus { get; set; }

        public virtual ApplicationUser MessageTo { get; set; }
        public virtual ApplicationUser MessageFrom { get; set; }
    }
}
