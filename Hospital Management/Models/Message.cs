using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public string Content { get; set; }
        public DateTime SentDateTime { get; set; }
    }
}
