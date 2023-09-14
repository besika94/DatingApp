
namespace API.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public string SenderUsername { get; set; }

        public string SenderPhotoUrl { get; set; }  

        public int ReipientId { get; set; }

        public string ReipientUsername { get; set; }

        public string ReipientPhotoUrl { get; set; }

        public string Content { get; set; }

        public DateTime? DateRead { get; set; }

        public DateTime MessageSent { get; set; }
    }
}
